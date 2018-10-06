using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfEntityDb.Vistas
{
    /// <summary>
    /// Lógica de interacción para Razas.xaml
    /// </summary>
    public partial class Razas : Window
    {
        public Razas()
        {
            InitializeComponent();
        }

        private void Raza_salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
