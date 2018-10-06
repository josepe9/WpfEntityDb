using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace WpfEntityDb.Models
{
    public class Color : INotifyObject
    {
        public Color()
        {
            oAnimal = new ObservableCollection<Animal>();
        }

        public override string ToString()
        {
            return Nombre + " " + ColorID;
        }

        public int ColorID { get { return colorId; } set { if (colorId != value) { colorId = value; OnPropertyChanged(); } } }
        private int colorId;

        [StringLength(60)]
        private string nombre;
        public string Nombre { get { return nombre; } set { if (nombre != value) { nombre = value; OnPropertyChanged(); } } }

        public virtual ObservableCollection<Animal> oAnimal { get { return oanimal; } set { oanimal = value; OnPropertyChanged(); } }
        private ObservableCollection<Animal> oanimal;
    }
}

