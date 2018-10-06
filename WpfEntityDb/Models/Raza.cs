using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace WpfEntityDb.Models
{
    public class Raza : INotifyObject
    {
        public Raza()
        {
           oAnimal = new ObservableCollection<Animal>();
        }

        public override string ToString()
        {
            return Nombre + " " + RazaID;
        }
        public int RazaID { get { return razaId; } set { if (razaId != value) { razaId = value; OnPropertyChanged(); } } }
        private int razaId;

        [StringLength(60)]
        private string nombre;
        public string Nombre { get { return nombre; } set { if (nombre != value) { nombre = value; OnPropertyChanged(); } } }

        [StringLength(200)]
        private string detalle;
        public string Detalle { get { return detalle; } set { if (detalle != value) { detalle = value; OnPropertyChanged(); } } }

        public virtual ObservableCollection<Animal> oAnimal { get { return oanimal; } set { oanimal = value; OnPropertyChanged(); } }
        private ObservableCollection<Animal> oanimal;
    }
}
