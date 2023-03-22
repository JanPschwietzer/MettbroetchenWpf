using System.Windows;
using System.Windows.Input;

namespace MettbrötchenWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void MinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void EinladenButtonClick(object sender, RoutedEventArgs e)
        {
            EinladungsWindow einladungeditor = new EinladungsWindow();
            einladungeditor.Show();
        }
        private void RechnungsButtonClick(object sender, RoutedEventArgs e)
        {
            RechnungsWindow rechnungseditor = new RechnungsWindow();
            rechnungseditor.Show();
        }
    }
}