using System;
using System.ComponentModel.DataAnnotations;

namespace WpfEntityDb.Models
{
    public class Animal : INotifyObject
    {
        public override string ToString()
        {
            return Nombre + " " + AnimalID;
        }

        [Key]
        public int AnimalID { get { return animalId; } set { if (animalId != value) { animalId = value; OnPropertyChanged(); } } }
        private int animalId;

        [StringLength(60)]
        private string nombre;
        public string Nombre { get { return nombre; } set { if (nombre != value) { nombre = value; OnPropertyChanged(); } } }

        //[ForeignKey("oRazas")]
        public int RazaID { get { return razaId; } set { if (razaId != value) { razaId = value; OnPropertyChanged(); } } }
        private int razaId;
        public virtual Raza oRazas { get; set; }

        private DateTime fechaNac;
        public DateTime FechaNac { get { return fechaNac; } set { if (fechaNac != value) { fechaNac = value; OnPropertyChanged(); } } }

        // [ForeignKey("oColor")]
        public int ColorID { get { return color; } set { if (color != value) { color = value; OnPropertyChanged(); } } }
        private int color;
        public virtual Color oColores { get; set; }

        private int peso;
        public int Peso { get { return peso; } set { if (peso != value) { peso = value; OnPropertyChanged(); } } }

        private decimal valor;
        public decimal Valor { get { return valor; } set { if (valor != value) { valor = value; OnPropertyChanged(); } } }

    }
}
