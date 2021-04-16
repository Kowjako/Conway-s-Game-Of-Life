using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DispatcherTimer redrawTimer = new DispatcherTimer();
            redrawTimer.Interval = new System.TimeSpan(0, 0, 0, 0, 50);
            redrawTimer.Tick += redrawCanvas;
            InitializeComponent();
        }

        private void redrawCanvas(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DockPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
