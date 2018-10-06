using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WpfEntityDb.Data;
using WpfEntityDb.Models;


namespace WpfEntityDb.ViewModel
{
    public class ColorVM : INotifyObject
    {
        public RelayCommand cmd_Insertar { get; set; }
        public RelayCommand cmd_Consultar { get; set; }
        public RelayCommand cmd_Borrar { get; set; }
        public RelayCommand cmd_Modifica { get; set; }

        public Color Color { get { return color; } set { color = value; OnPropertyChanged(); } }
        private Color color;

        public ObservableCollection<Color> ListaC { get { return listac; } set { listac = value; OnPropertyChanged(); } }

        private ObservableCollection<Color> listac = new ObservableCollection<Color>();

        public ColorVM()
        {
            this.cmd_Insertar = new RelayCommand(p => this.Insertar());
            this.cmd_Consultar = new RelayCommand(p => this.Consultar());
            this.cmd_Borrar = new RelayCommand(p => this.Borrar());
            this.cmd_Modifica = new RelayCommand(p => this.Modifica());
            this.Color = new Color();
        }

        public void Insertar()
        {
            using (var dbc = new WpfEntityDbContext())
            {
                if (this.Color.Nombre == null)
                {
                    MessageBox.Show("No digitó el nombre del color a insertar");
                    return;
                }
                dbc.Colores.Add(this.Color);
                try
                {
                    dbc.SaveChanges();
                    this.Consultar();
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error " + er.Message);
                    if (er.InnerException != null)
                        MessageBox.Show("Error " + er.InnerException.Message);
                }
            }
        }

        public void Consultar()
        {
            using (var dbc = new WpfEntityDbContext())
            {
                this.ListaC = new ObservableCollection<Color>(dbc.Colores);
            }
        }

        public void Borrar()
        {
            if (this.Color.Nombre == null)
            {
                MessageBox.Show("No digitó el color a borrar");
                return;
            }

            using (var dbc = new WpfEntityDbContext())
            {
                try
                {
                    var borr = (from p in dbc.Colores
                                where p.Nombre == this.Color.Nombre
                                select p).Single();
                    dbc.Colores.Remove(borr);
                    dbc.SaveChanges();
                    this.ListaC = new ObservableCollection<Color>(dbc.Colores);
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error " + er.Message);
                    if (er.InnerException != null)
                        MessageBox.Show("Error " + er.InnerException.Message);
                }
            }
        }

        public void Modifica()
        {
            if (this.Color.Nombre == null)
            {
                MessageBox.Show("No digitó el nombre del color a modificar");
                return;
            }
            using (var dbc = new WpfEntityDbContext())
            {
                var color = dbc.Colores.Find(this.Color.ColorID);
                color.Nombre = this.Color.Nombre;
                try
                {
                    dbc.SaveChanges();
                    this.Consultar();
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error " + er.Message);
                    if (er.InnerException != null)
                        MessageBox.Show("Error " + er.InnerException.Message);
                }
            }
        }
    }
}
