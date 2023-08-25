using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        private readonly Dictionary<PlayerEnum, ImageSource> PlayerPNG = new()
        {
            {PlayerEnum.X, new BitmapImage(new Uri(@"C:\Users\Ethan\Desktop\WPF app TicTacToe\C#\TicTacToe\Assets\X.png")) },
            {PlayerEnum.O, new BitmapImage(new Uri(@"C:\Users\Ethan\Desktop\WPF app TicTacToe\C#\TicTacToe\Assets\O.png")) }
        };

        private readonly Image[] Controls = new Image[9];
        private readonly GameBoard CurrentGame = new();
        public MainWindow()
        {
            InitializeComponent();
            SetUpGrid();
            CurrentGame.MoveMade += MoveMade;
        }

        private void SetUpGrid()
        {
            for (int i = 0; i < 9; i++)
            {
                Image Control = new Image();
                GameGrid.Children.Add(Control);
                Controls[i] = Control;
            }
        }

        private void MoveMade(int i)
        {
            
            PlayerEnum player = CurrentGame.PlayerPlaying;
            Controls[i].Source = PlayerPNG[player];
        }


        private void GameGrid_Press(object sender,MouseButtonEventArgs e)
        {
            double Width = GameGrid.ActualWidth / 3;
            double Height = GameGrid.ActualHeight / 3;
            Point MousePosition = e.GetPosition(GameGrid);
            int row = (int)(MousePosition.Y / Width);
            int col = (int)(MousePosition.X / Height);
            int temp = -1;
            MessageBox.Show($"Clicked on cell: Row {row}, Column {col}");
            if (row == 0) {
                if (col == 0){ temp = 0; }
                else if (col == 1) { temp = 1; }
                else if (col == 2) { temp = 2; }
            }
            else if (row == 1) {
                if (col == 0) { temp = 3; }
                else if (col == 1) { temp = 4; }
                else if (col == 2) { temp = 5; }
            }
            else if (row == 2)
            {
                if (col == 0) { temp = 6; }
                else if (col == 1) { temp = 7; }
                else if (col == 2) { temp = 8; }
            }
            if (temp != -1)
            {
                bool v = CurrentGame.PossibleMove(temp);
                if (v) { 
                    MoveMade(temp);
                    CurrentGame.SwitchTurns();
                }
            }
        }





    }
}
