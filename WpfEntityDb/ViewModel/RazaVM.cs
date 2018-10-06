using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WpfEntityDb.Data;
using WpfEntityDb.Models;

namespace WpfEntityDb.ViewModel
{
    class RazaVM : INotifyObject
    {
        public RelayCommand cmd_Insertar { get; set; }
        public RelayCommand cmd_Consultar { get; set; }
        public RelayCommand cmd_Borrar { get; set; }
        public RelayCommand cmd_Modifica { get; set; }

        //public bool EsModifica { get; set; }

        public Raza Raza { get { return raza; } set { raza = value; OnPropertyChanged(); } }
        private Raza raza;

        public ObservableCollection<Raza> Lista { get { return lista; } set { lista = value; OnPropertyChanged(); } }
        private ObservableCollection<Raza> lista = new ObservableCollection<Raza>();

        public RazaVM()
        {
            this.cmd_Insertar = new RelayCommand(p => this.Insertar());
            this.cmd_Consultar = new RelayCommand(p => this.Consultar());
            this.cmd_Borrar = new RelayCommand(p => this.Borrar());
            this.cmd_Modifica = new RelayCommand(p => this.Modifica());
            this.Raza = new Raza();
        }

        public void Insertar()
        {
            using (var dbc = new WpfEntityDbContext())
            {
                if (this.Raza.Nombre == null)
                {
                    MessageBox.Show("No digitó el nombre de la raza a insertar");
                    return;
                }
                dbc.Razas.Add(this.Raza);
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
                this.Lista = new ObservableCollection<Raza>(dbc.Razas);
            }
        }

        public void Borrar()
        {
            if (this.Raza.Nombre == null)
            {
                MessageBox.Show("No digitó la raza a borrar");
                return;
            }

            using (var dbc = new WpfEntityDbContext())
            {
                try
                {
                    var borr = (from p in dbc.Razas
                                where p.Nombre == this.Raza.Nombre
                                select p).Single();
                    dbc.Razas.Remove(borr);
                    dbc.SaveChanges();
                    this.Lista = new ObservableCollection<Raza>(dbc.Razas);
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
            if (this.Raza.Nombre == null)
            {
                MessageBox.Show("No digitó el nombre de la raza a modificar");
                return;
            }
            using (var dbc = new WpfEntityDbContext())
            {
                var raza = dbc.Razas.Find(this.Raza.RazaID);
                //dbc.Razas.Attach(raza);
                raza.Detalle = this.Raza.Detalle;
                raza.Nombre = this.Raza.Nombre;
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
