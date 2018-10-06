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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfEntityDb.Controles
{
    /// <summary>
    /// Lógica de interacción para BotonA.xaml
    /// </summary>
    public partial class BotonA : UserControl
    {


        public string Texto
        {
            get { return (string)GetValue(TextoProperty); }
            set { SetValue(TextoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Texto.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextoProperty =
            DependencyProperty.Register("Texto", typeof(string), typeof(BotonA), new PropertyMetadata("1"));


        public BotonA()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
