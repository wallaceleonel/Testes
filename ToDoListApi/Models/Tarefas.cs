using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListApi.Models
{
    [Table(name:"Tarefas")]
    public class Tarefas
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(120)]
        public string Titulo { get; set; }
        [MaxLength(500)]
        public string Detalhes { get; set; }
        public DateTime DateTarefa { get; set; }
    }
}
