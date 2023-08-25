using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

        }


        private void GameGrid_Press(object sender,MouseButtonEventArgs e)
        {
            double Size = GameGrid.Width / 3;
            Point MousePosition = e.GetPosition(GameGrid);
            int row = (int)(MousePosition.Y / Size);
            int col = (int)(MousePosition.X / Size);
            //bool v = GameBoard.PossibleMove(4);
            //Changes to be made in the Logic of the game to work properly.
        }





    }
}
