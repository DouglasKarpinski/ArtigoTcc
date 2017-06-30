using System.ComponentModel.DataAnnotations;

namespace Noticias.Models
{
    public class UnidadeNegocio: Base
    {
        [MaxLength(100)]
        public string Nome { get; set; }
    }
}
