using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameBoard
    {
        public int[] Board;

        public PlayerEnum PlayerPlaying { get; private set; }


        public event Action<GameBoard> GameBoardChanged;
        public event Action<int> MoveMade;

        public GameBoard()
        {
            Board = new int[9];
            GameBegin();
        }
        public void GameBegin() {
            //Board = new int[9];
            PlayerPlaying = PlayerEnum.X;
        }

        public void SwitchTurns()
        {
            if (PlayerPlaying == PlayerEnum.X)
            {
                PlayerPlaying = PlayerEnum.O;
            }
            else
            {
                PlayerPlaying = PlayerEnum.X;
            }
        }
        public bool PossibleMove(int pos)  {
            if (Board[pos] == 0 )  {
                Console.WriteLine((int)PlayerPlaying);
                Board[pos] = (int)PlayerPlaying;
                return true;
            }
            return false;
        }

        public bool WinningMove(PlayerEnum Player)
        {
            Dictionary<int, List<int[]>> winConDictionary = new Dictionary<int, List<int[]>>();

            winConDictionary.Add(1, new List<int[]> {
                new int[] { 0, 1, 2 }, // Top row
                new int[] { 3, 4, 5 }, // Middle row hori
                new int[] { 6, 7, 8 }  // Bottom row 
            });

            winConDictionary.Add(2, new List<int[]>
            {
                new int[] { 0, 3, 6 }, // Left column
                new int[] { 1, 4, 7 }, // Middle column vert
                new int[] { 2, 5, 8 }, // Right column

            });

            winConDictionary.Add(3, new List<int[]>
            {
                new int[] { 0, 4, 8 }//TopLeftToBottomRight,
            });

            winConDictionary.Add(4, new List<int[]>
            {
                new int[] { 2, 4, 6 }//TopRighToBottomLeft,
            });

            foreach (var Position in  winConDictionary)
            {
                int winConKey = Position.Key;
                List<int[]> winConList = Position.Value;

                foreach (int[] winCon in winConList)
                {
                    bool hasWon = true;

                    foreach (int Square in winCon)
                    {
                        if (Board[Square] != (int)Player)
                        {
                            hasWon = false;
                            break;
                        }
                    }

                    if (hasWon)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
