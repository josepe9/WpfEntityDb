using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Windows;
using WpfEntityDb.Data;
using WpfEntityDb.Models;

namespace WpfEntityDb.Vistas
{
    /// <summary>
    /// Lógica de interacción para RazasRep.xaml
    /// </summary>
    public partial class RazasRep : Window
    {
        WpfEntityDbContext dataEntities = new WpfEntityDbContext();
        
        public RazasRep()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           /* ObjectQuery<Raza> razas = dataEntities.Razas;
            var query =
            from product in razas
            where product.Nombre == "Torbellino"
            orderby product.Nombre
            select new { product.Nombre, product.Detalle, product.RazaID };
        
            GridLocal.ItemsSource = query.ToList(); */
        }

        private void Salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
