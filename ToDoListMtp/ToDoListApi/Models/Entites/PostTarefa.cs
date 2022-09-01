using System.ComponentModel.DataAnnotations;

namespace ToDoListApi.Models.Entites
{
    public class PostTarefa
    {
        [Required]
        public string Titulo { get; set; }
        [MaxLength(500)]
        public string Detalhes { get; set; }
        public DateTime DateTarefa { get; set; }
    }
}
