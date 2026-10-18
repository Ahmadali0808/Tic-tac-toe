using System.Windows;
using System.Windows.Controls;

namespace Tic_tac_toe
{
    public partial class MainWindow : Window
    {
        private bool isXTurn = true;
        private XOcell[,] cells = new XOcell[3, 3];

        public MainWindow()
        {
            InitializeComponent();
            InitializeGameGrid();
        }

        private void InitializeGameGrid()
        {
            int index = 0;
            foreach (var child in GameGrid.Children)
            {
                if (child is XOcell cell)
                {
                    int row = index / 3;
                    int col = index % 3;
                    cells[row, col] = cell;
                    index++;
                }
            }
        }

        private void XOcell_Clicked(object sender, RoutedEventArgs e)
        {
            var cell = sender as XOcell;
            if (cell != null && string.IsNullOrEmpty(cell.Value))
            {
                cell.Value = isXTurn ? "X" : "O";
                isXTurn = !isXTurn;

                if (CheckForWin())
                {
                    ShowWinMessage();
                }
                else if (CheckForDraw())
                {
                    ShowDrawMessage();
                }
            }
        }

        private bool CheckForWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (CheckLine(cells[i, 0], cells[i, 1], cells[i, 2]) ||
                    CheckLine(cells[0, i], cells[1, i], cells[2, i]))
                {
                    return true;
                }
            }
            if (CheckLine(cells[0, 0], cells[1, 1], cells[2, 2]) ||
                CheckLine(cells[0, 2], cells[1, 1], cells[2, 0]))
            {
                return true;
            }
            return false;
        }

        private bool CheckLine(XOcell cell1, XOcell cell2, XOcell cell3)
        {
            return !string.IsNullOrEmpty(cell1.Value) &&
                   cell1.Value == cell2.Value &&
                   cell2.Value == cell3.Value;
        }

        private bool CheckForDraw()
        {
            foreach (var cell in cells)
            {
                if (string.IsNullOrEmpty(cell.Value))
                {
                    return false;
                }
            }
            return true;
        }

        private void ShowWinMessage()
        {
            WinMessage.Text = isXTurn ? "O Wins!" : "X Wins!";
            WinMenu.Visibility = Visibility.Visible;
            GameGrid.Visibility = Visibility.Collapsed;
        }

        private void ShowDrawMessage()
        {
            DrawMenu.Visibility = Visibility.Visible;
            GameGrid.Visibility = Visibility.Collapsed;
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            StartMenu.Visibility = Visibility.Collapsed;
            GameGrid.Visibility = Visibility.Visible;
        }

        private void PlayAgainButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset the game state
            foreach (var cell in cells)
            {
                cell.Value = string.Empty;
            }
            isXTurn = true;

            WinMenu.Visibility = Visibility.Collapsed;
            DrawMenu.Visibility = Visibility.Collapsed;
            GameGrid.Visibility = Visibility.Visible;
        }
    }
}
