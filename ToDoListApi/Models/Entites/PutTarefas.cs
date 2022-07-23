using System.ComponentModel.DataAnnotations;

namespace ToDoListApi.Models.Entites
{
    public class PutTarefas : PostTarefa
    {
        public int Id { get; set; } 
    }
}
