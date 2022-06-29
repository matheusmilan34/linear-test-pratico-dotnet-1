using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CanalVenda
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Descricao { get; set; }
    }
}
