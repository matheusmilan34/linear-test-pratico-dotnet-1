using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Produto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Descricao { get; set; }

        [Required]
        [MinLength(1)]
        public List<CanalVenda> CanaisVendas { get; set; }
    }
}
