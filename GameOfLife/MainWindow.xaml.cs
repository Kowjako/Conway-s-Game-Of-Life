using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public partial class MainWindow : Window
    {
        const int boardWidth = 1040, boardHeight = 760;
        const int cellSize = 10;
        static TimeSpan delay = new TimeSpan(0, 0, 0, 0, 100);
        bool gameIsStarted = false;
        DispatcherTimer timer;
        Rectangle[,] mainBoard;
        int density = 0, time, liveCells;

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Button events
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            density = Convert.ToInt32(densityBox.Text);
            time = Convert.ToInt32(timeBox.Text);
            CreateStartGeneration();
            if (!gameIsStarted)
                StartGame(); 
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            StopGame();
        }
        #endregion

        #region Static events 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CreateBoard();
        }

        private void DockPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion

        #region GameMethods 
        private void CreateBoard()
        {
            canvas.Children.Clear();
            mainBoard = new Rectangle[boardHeight / cellSize, boardWidth / cellSize];
            for (int i = 0; i < boardHeight / cellSize; i++)
            {
                for (int j = 0; j < boardWidth / cellSize; j++)
                {
                    /*Sprawdzenie warunków brzegowych, dla rysowania obwodu */
                    if (i == 0 || i == boardHeight / cellSize - 1 || j == 0 || j == boardWidth / cellSize - 1)
                    {
                        Rectangle r = new Rectangle
                        {
                            Width = cellSize,
                            Height = cellSize,
                            Stroke = Brushes.Gray,
                            StrokeThickness = 0.5,
                            Fill = Brushes.DarkGreen,
                        };
                        mainBoard[i, j] = r;
                        Canvas.SetLeft(r, j * cellSize);
                        Canvas.SetTop(r, i * cellSize);
                        canvas.Children.Add(r);
                    }
                    else
                    {
                        /* Rysowanie klatek do użycia */
                        Cell Cell = new Cell { State = false, Column = i, Row = j };
                        Rectangle r = new Rectangle
                        {
                            Width = cellSize,
                            Height = cellSize,
                            Stroke = Brushes.Gray,
                            StrokeThickness = 0.5,
                            Fill = Brushes.White,
                            Tag = Cell
                        };
                        mainBoard[i, j] = r;
                        Canvas.SetLeft(r, j * cellSize);
                        Canvas.SetTop(r, i * cellSize);
                        canvas.Children.Add(r);
                    }
                }
            }
        }

        private void CreateStartGeneration()
        {
            Random r = new Random();
            foreach(Rectangle c in mainBoard)
            {
                if (c.Tag != null)
                {
                    var oneCell = (Cell)c.Tag;
                    oneCell.State = r.Next(0, density) == 0;
                    if (oneCell.State)
                    {
                        oneCell.State = true;
                        mainBoard[oneCell.Column, oneCell.Row].Fill = Brushes.Orange;
                        liveCells++;
                    }
                }
            }
        }

        private void StartGame()
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, time);
            timer.Tick += DrawNextGeneration;
            timer.Start();
            gameIsStarted = true;
        }

        private void StopGame()
        {
            timer.Stop();
            gameIsStarted = false;
        }

        private void DrawNextGeneration(object sender, EventArgs e)
        {
            if (liveCells > 0)
                NextStep();
            else timer.Stop();
        }


        #endregion
    }
}
