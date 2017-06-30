using System.ComponentModel.DataAnnotations;

namespace Noticias.Models.ViewModels
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; }
    }
}
