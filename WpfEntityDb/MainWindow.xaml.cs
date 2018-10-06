using System.Windows;
using WpfEntityDb.Vistas;

namespace WpfEntityDb
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Animales(object sender, RoutedEventArgs e)
        {
            Animales venani = new Animales();
            venani.Show();

        }

        private void Razas(object sender, RoutedEventArgs e)
        {
            Razas venraz = new Vistas.Razas();
            venraz.Show();
        }

        private void Salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Colores(object sender, RoutedEventArgs e)
        {
            Colores vencol = new Vistas.Colores();
            vencol.Show();
        }

        private void Informes(object sender, RoutedEventArgs e)
        {
            RazasRep RP = new Vistas.RazasRep();
            RP.Show();
        }
    }
}
