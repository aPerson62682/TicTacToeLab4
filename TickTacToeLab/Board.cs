using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TickTacToeLab
{
    internal class Board
    {
        PlayerEnum[,] board = new PlayerEnum[3, 3];
        PlayerEnum currentPlayer = PlayerEnum.X;

        public Board()
        {
            ResetBoard();
        }

        public void ResetBoard()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    board[x, y] = PlayerEnum.NONE;
                }
                currentPlayer = PlayerEnum.X;
            }

        }

        public bool PlaceMove(int x, int y)
        {
            if (board[x, y] == PlayerEnum.NONE)
            {
                board[x, y] = currentPlayer;
                return true;
            }
            return false;
        }

        public void SwitchPlayers()
        {
            if (currentPlayer == PlayerEnum.X)
            {
                currentPlayer = PlayerEnum.O;
            }
            else
            {
                currentPlayer = PlayerEnum.X;
            }
        }
        public PlayerEnum WinnerCheck()
        {
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == currentPlayer &&
                board[row, 1] == currentPlayer &&
                board[row, 2] == currentPlayer)
                {
                    return currentPlayer;
                }
          }
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == currentPlayer &&
                board[1, col] == currentPlayer &&
                board[2, col] == currentPlayer)
            {
                    return currentPlayer;
            }
          }
            if (board[0, 0] == currentPlayer &&
                board[1, 1] == currentPlayer &&
                board[2, 2] == currentPlayer)
            {
               return currentPlayer;
          }
            if (board[0, 2] == currentPlayer &&
                board[1, 1] == currentPlayer &&
                board[2, 0] == currentPlayer)
           {
                return currentPlayer;
          }

            return PlayerEnum.NONE;
      }

        public bool DrawCheck ()
        {
            foreach (var cell in board)
            {
                if (cell == PlayerEnum.NONE) return false;
            }
                    return true;
                }
            }
        }

