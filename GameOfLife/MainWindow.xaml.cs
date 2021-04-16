using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Drawing;
using System;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int resolution;
        DispatcherTimer redrawTimer;
        private bool[,] field;

        private int rows, columns;

        public MainWindow()
        {
            redrawTimer = new DispatcherTimer();
            redrawTimer.Interval = new System.TimeSpan(0, 0, 0, 0, 50);
            redrawTimer.Tick += redrawCanvas;
            InitializeComponent();
        }

        private void redrawCanvas(object sender, System.EventArgs e)
        {
            DrawNextGeneration();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DockPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            StartLife();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StartLife()
        {
            /** Warunki do początku gry **/
            if (redrawTimer.IsEnabled) return;
            if (String.IsNullOrEmpty(resolutionBox.Text) || Convert.ToInt32(resolutionBox.Text) > 25) return;

            /*Inicjalizacja parametrów **/
            resolution = Convert.ToInt32(resolutionBox.Text);
            resolutionBox.IsEnabled = false;
            densityBox.IsEnabled = false;

            rows = (int)canvas.Height / resolution;
            columns = (int)canvas.Width / resolution;
            field = new bool[columns, rows]; /* Zeby zwracanie bylo jako X i Y czyli X - kolumna, Y - wiersz */
            createStartGeneration(); /* Tworzenie początkowej instancji */
            redrawTimer.Start(); /* Uruchomienie redraw timera */
        }

        private void createStartGeneration()
        {
            Random r = new Random();
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    field[x, y] = r.Next(Convert.ToInt32(densityBox.Text)) == 0; /* Im wieksza gestosc tym mneijsza szansa ze klatka będzie żywa */
                }
            }
        }

        private void DrawNextGeneration()
        {

        }
    }
}
