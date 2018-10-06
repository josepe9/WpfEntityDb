using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WpfEntityDb.Data;
using WpfEntityDb.Models;

namespace WpfEntityDb.ViewModel
{
    class AnimalVM : INotifyObject
    {
        public RelayCommand cmd_Insertar { get; set; }
        public RelayCommand cmd_Consultar { get; set; }
        public RelayCommand cmd_Borrar { get; set; }
        public RelayCommand cmd_Modifica { get; set; }
        public Animal Animal { get { return animal; } set { animal = value; OnPropertyChanged(); } }
        private Animal animal;


        public ObservableCollection<Animal> Lista { get { return lista; } set { lista = value; OnPropertyChanged(); } }
        private ObservableCollection<Animal> lista = new ObservableCollection<Animal>();

        public ObservableCollection<Raza> ListaR { get { return listaR; } set { listaR = value; OnPropertyChanged(); } }
        private ObservableCollection<Raza> listaR = new ObservableCollection<Raza>();

        public ObservableCollection<Color> ListaC { get { return listaC; } set { listaC = value; OnPropertyChanged(); } }
        private ObservableCollection<Color> listaC = new ObservableCollection<Color>();

        public AnimalVM()
        {
            this.cmd_Insertar = new RelayCommand(p => this.Insertar());
            this.cmd_Consultar = new RelayCommand(p => this.Consultar());
            this.cmd_Borrar = new RelayCommand(p => this.Borrar());
            this.cmd_Modifica = new RelayCommand(p => this.Modifica());
            this.Animal = new Animal();

            using (var dbc = new WpfEntityDbContext())
            {
                this.Lista = new ObservableCollection<Animal>(dbc.Animales);
                this.ListaR = new ObservableCollection<Raza>(dbc.Razas);
                this.ListaC = new ObservableCollection<Color>(dbc.Colores);
            }
            this.Animal.FechaNac = DateTime.Now.Date;
        }

        public void Insertar()
        {
            using (var dbc = new WpfEntityDbContext())
            {
                if (this.Animal.Nombre == null)
                {
                    MessageBox.Show("No digitó el nombre del animal a insertar");
                    return;
                }
                dbc.Animales.Add(this.Animal);
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
                this.Lista = new ObservableCollection<Animal>(dbc.Animales);
                this.ListaR = new ObservableCollection<Raza>(dbc.Razas);
                this.ListaC = new ObservableCollection<Color>(dbc.Colores);
            }
        }

        
        public void Borrar()
        {
            if (this.Animal.Nombre == null)
            {
                MessageBox.Show("No digitó el animal a borrar");
                return;
            }

            using (var dbc = new WpfEntityDbContext())
            {
                try
                {
                    var borr = (from p in dbc.Animales
                                where p.Nombre == this.Animal.Nombre
                                select p).Single();
                    dbc.Animales.Remove(borr);
                    dbc.SaveChanges();
                    this.Lista = new ObservableCollection<Animal>(dbc.Animales);
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
            if (this.Animal.Nombre == null)
            {
                MessageBox.Show("No digitó el nombre del animal a modificar");
                return;
            }
            using (var dbc = new WpfEntityDbContext())
            {
                var animal = dbc.Animales.Find(this.Animal.AnimalID);
                animal.RazaID = this.Animal.RazaID;
                animal.Nombre = this.Animal.Nombre;
                animal.FechaNac = this.Animal.FechaNac;
                animal.ColorID = this.Animal.ColorID;
                animal.Peso = this.Animal.Peso;
                animal.Valor = this.Animal.Valor;
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
