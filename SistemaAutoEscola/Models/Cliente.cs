using System.ComponentModel;

namespace SistemaAutoEscola.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        [DisplayName("Nome")]
        public string? NomeCliente { get; set; }
        [DisplayName("Turma")]
        public string? Turma { get; set; }
        [DisplayName("Foi aprovado pelo detran?")]
        public Boolean AprovadoDetran { get; set; }
    }
}
