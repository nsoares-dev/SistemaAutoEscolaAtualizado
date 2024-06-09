using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SistemaAutoEscola.Models
{
    public class Reserva
    {
        public int ReservaId { get; set; }
        [DisplayName("Reservado para")]
        public int ClienteId { get; set; } // nome do ser 
        [DisplayName("CarroId")]
        public int CarroId { get; set; } // carro reservado 
        [DisplayName("Data da Reserva")]
        [DataType(DataType.DateTime)]
        public DateTime DataReserva { get; set; }
        public Carro? Carro { get; set; }
        public Cliente? Cliente { get; set; }

    }
}
