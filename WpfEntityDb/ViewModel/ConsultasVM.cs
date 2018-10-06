using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using WpfEntityDb.Data;
using WpfEntityDb.Models;

namespace WpfEntityDb.ViewModel
{
    public class ConsultasVM : INotifyObject
    {
        public RelayCommand cmd_ConRaz { get; set; }
        public RelayCommand cmd_ConCol { get; set; }
        public RelayCommand cmd_ConAni { get; set; }
        public RelayCommand cmd_ConRGr { get; set; }

        public class Resultado
        {
            public int Animal { get; set; }
            public string Nombre { get; set; }
            public string Color { get; set; }
            public string Raza { get; set; }
            public int Peso { get; set; }
            public DateTime FechaNac { get; set; }
            public Decimal  Valor { get; set; }
        }

        public Raza Raza { get { return raza; } set { raza = value; OnPropertyChanged(); } }
        private Raza raza;


        public ObservableCollection<Animal> ListaA { get { return listaA; } set { listaA = value; OnPropertyChanged(); } }
        private ObservableCollection<Animal> listaA = new ObservableCollection<Animal>();

        public ObservableCollection<Raza> ListaR { get { return listaR; } set { listaR = value; OnPropertyChanged(); } }
        private ObservableCollection<Raza> listaR = new ObservableCollection<Raza>();

        public ObservableCollection<Color> ListaC { get { return listaC; } set { listaC = value; OnPropertyChanged(); } }
        private ObservableCollection<Color> listaC = new ObservableCollection<Color>();

        public ObservableCollection<Resultado> ListaV { get { return listv; } set { listv = value; OnPropertyChanged(); } }
        public ObservableCollection<Resultado> listv = new ObservableCollection<Resultado>();

       /* public DataSet dataset = new DataSet("Table");
        public DataTable dt = new DataTable();
        DataColumn column;
        DataRow row; */
        
        public ConsultasVM()
        {
            this.cmd_ConRaz = new RelayCommand(p => this.ConRaz());
            this.cmd_ConCol = new RelayCommand(p => this.ConCol());
            this.cmd_ConAni = new RelayCommand(p => this.ConAni());
            this.cmd_ConRGr = new RelayCommand(p => this.ConRGr());
           // crearTable();
        }

        public void ConRaz()
        {
            using (var dbc = new WpfEntityDbContext())
            {
                this.ListaR = new ObservableCollection<Raza>(dbc.Razas);
            }
        }

        public void ConCol()
        {
            using (var dbc = new WpfEntityDbContext())
            {
                this.ListaC = new ObservableCollection<Color>(dbc.Colores);
            }
        }

        public void ConAni()
        {
            using (var dbc = new WpfEntityDbContext())
            {
                this.ListaA = new ObservableCollection<Animal>(dbc.Animales);
            }
        }

        /*
        public void crearTable()
        {
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "AnimalID";
            column.ReadOnly = true;
            column.Unique = true;
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Nombre";
            column.AutoIncrement = false;
            column.Caption = "Nombre animal";
            column.ReadOnly = false;
            column.Unique = false;
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Color";
            column.AutoIncrement = false;
            column.Caption = "Color";
            column.ReadOnly = false;
            column.Unique = false;
            dt.Columns.Add(column);

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = dt.Columns["AnimalID"];
            dt.PrimaryKey = PrimaryKeyColumns;

         //   dataset = new DataSet();
            dataset.Tables.Add(dt);
        } */

        public void ConRGr()
        {
            /*
            dt.Clear();
            row = dt.NewRow();
            row["AnimalID"] = 1;
            row["Nombre"] = "Lola ";
            row["Color"] = "Negro";
            dt.Rows.Add(row);   */

            using (var dbc = new WpfEntityDbContext())
            {
                //Consultar de las listas
                /* var sql = from a in ListaA
                          join c in ListaC
                          on a.ColorID equals c.ColorID
                          join d in ListaR
                          on a.RazaID equals d.RazaID
                          select new 
                          {
                              AnimalID = a.AnimalID,
                              ColorID = c.ColorID,
                              NombreA = a.Nombre,
                              NombreC = c.Nombre,
                              NombreR = d.Nombre
                          };   */

                var sql1 = from an in dbc.Animales
                           join co in dbc.Colores
                           on an.ColorID equals co.ColorID
                           join ra in dbc.Razas
                           on an.RazaID equals ra.RazaID
                           select new
                           {
                               AnimalID = an.AnimalID,
                               ColorID = co.ColorID,
                               NombreA = an.Nombre,
                               NombreC = co.Nombre,
                               NombreR = ra.Nombre,
                               Peso = an.Peso,
                               FechaNac = an.FechaNac,
                               Valor = an.Valor
                           };

                //var sql = dbc.Animales.Include("Colores");
                //para llenar la datatable
                /*  foreach(var mostrar in sql)
                  {
                      row = dt.NewRow();
                      row["AnimalID"] = mostrar.AnimalID;
                      row["Nombre"] = mostrar.NombreA;
                      row["Color"] = mostrar.NombreC;
                      dt.Rows.Add(row);
                  }  */
                ListaV.Clear();
                foreach (var mostrar in sql1)
                {
                    listv.Add(new Resultado() { Animal = mostrar.AnimalID,
                        Nombre = mostrar.NombreA,
                        Color = mostrar.NombreC,
                        Raza = mostrar.NombreR ,
                        Peso = mostrar.Peso,
                        FechaNac = mostrar.FechaNac,
                        Valor = mostrar.Valor
                    });
                }
            }
        }
    }
}
