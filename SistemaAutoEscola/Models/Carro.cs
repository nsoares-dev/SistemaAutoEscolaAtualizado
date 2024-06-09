using System.ComponentModel;

namespace SistemaAutoEscola.Models
{
    public class Carro
    {
        public int CarroId { get; set; }
        [DisplayName("Nome")]
        public string? NomeCarro { get; set; }
        [DisplayName("Modelo/Serie")]
        public string? ModeloCarro { get; set; }
        [DisplayName("Ano")]
        public string? Ano { get; set; }
        [DisplayName("Placa")]
        public string? Placa { get; set; }
        [DisplayName("Cor")]
        public string? Cor { get; set; }
        [DisplayName("Já foi reservado?")]
        public Boolean JaReservado { get; set; }
        public int ReservaId { get; set; }
    }
}
