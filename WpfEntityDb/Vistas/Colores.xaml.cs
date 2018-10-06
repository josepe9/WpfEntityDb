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
    /// Lógica de interacción para Colores.xaml
    /// </summary>
    public partial class Colores : Window
    {
        public Colores()
        {
            InitializeComponent();
        }

        private void Color_salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
