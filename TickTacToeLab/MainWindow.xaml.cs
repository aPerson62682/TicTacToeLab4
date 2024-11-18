using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace TickTacToeLab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool XPlayer = true;
        private string newImage;
        private int boardFull = 0;
        private int xWinCount = 0;
        private int oWinCount = 0;

        public MainWindow()
        {
            InitializeComponent();
            lblPlayerStatus.Content = "Good Luck! It's X's Turn to play.";
            ResetGame();

        }

        // CODE GIVEN IN CLASS EXAMPLE
        //private void blankImg0_0_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //   blankImg0_0.Source = new BitmapImage(new Uri("Images/tic-tac-toe_x.png", UriKind.Relative));
        //   blankImg0_1.Source = new BitmapImage(new Uri("Images/tic-tac-toe_x.png", UriKind.Relative));
        //   blankImg0_2.Source = new BitmapImage(new Uri("Images/tic-tac-toe_x.png", UriKind.Relative));

        //}
        private Board gameBoard = new Board();

        private void ResetGame()
        {
            gameBoard.ResetBoard();
            XPlayer = true;
            boardFull = 0;  
            lblPlayerStatus.Content = "Good Luck! It's X's Turn to play.";

            foreach (var child in BoardGrid.Children)
            {
                if (child is Image image)
                {
                    image.Source = new BitmapImage(new Uri("Images/blankImg.png", UriKind.Relative));
                }
            }
        }

        private void imageTemplate_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (sender is Image clickableImage)
            {
                int row = Grid.GetRow(clickableImage);
                int col = Grid.GetColumn(clickableImage);


                if (gameBoard.PlaceMove(row, col))
                {
                    if (XPlayer)
                    {
                        newImage = "Images/tic-tac-toe_x.png";
                        lblPlayerStatus.Content = "O's Turn";
                    }
                    else
                    {
                        newImage = "Images/tic-tac-toe_o.png";
                        lblPlayerStatus.Content = "X's Turn";
                    }


                    clickableImage.Source = new BitmapImage(new Uri(newImage, UriKind.Relative));

                    var winner = gameBoard.WinnerCheck();
                    if (winner != PlayerEnum.NONE)
                    {
                        if (winner == PlayerEnum.X)
                        {
                            xWinCount++;
                            lblXWinner.Content = $"X WINS: {xWinCount}";
                        }
                        else if (winner == PlayerEnum.O)
                        {
                            oWinCount++;
                            lblOWinner.Content = $"O WINS: {oWinCount}";
                        }

                        lblPlayerStatus.Content = $"Player {winner} Wins!!";
                        MessageBox.Show($"Player {winner} Wins!!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                        ResetGame();
                        return;
                    }

                    boardFull++;
                    if (boardFull >= 9 || gameBoard.DrawCheck())
                    {
                        lblPlayerStatus.Content = "FULL!";
                        MessageBox.Show("It's a draw!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                        ResetGame();
                        return;
                    }

                if (XPlayer)
                    {
                        XPlayer = false;
                    } else
                    {
                        XPlayer = true;
                    } 
                gameBoard.SwitchPlayers();

            }
            else
            {
                    MessageBox.Show("You Can't put it there!", "Invalid Move", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }

            private void btnClearBoard_Click(object sender, RoutedEventArgs e)
            {
                ResetGame();
            }

        private void btnResetPoints_Click(object sender, RoutedEventArgs e)
        {
            xWinCount = 0;
            oWinCount = 0;
            lblOWinner.Content = "O WINS: 0";
            lblXWinner.Content = "X WINS: 0";

        }

    
    }
    }
