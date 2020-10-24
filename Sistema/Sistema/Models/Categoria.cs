using System.ComponentModel.DataAnnotations;

namespace Sistema.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public string Descricao { get; set; }
    }
}