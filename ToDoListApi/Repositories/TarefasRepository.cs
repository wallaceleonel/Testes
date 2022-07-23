using ToDoListApi.Models;
using ToDoListApi.Models.Entites;

namespace ToDoListApi.Repositories
{
    public interface ITarefasRepository
    {
        public bool Create(PostTarefa tarefas);
        public Tarefas Read(int Id);
        public Tarefas Read(Tarefas tarefas);
        public bool Update(PutTarefas tarefas);
        public bool Delete(int Id);

    }
    public class TarefasRepository : ITarefasRepository
    {
        private readonly _DbContext db;
        public TarefasRepository(_DbContext _Db)
        {
            db = _Db;
        }
        public bool Create(PostTarefa tarefas)
        {
            try
            {
                var tarefas_db = new Tarefas()
                {
                    Titulo = tarefas.Titulo,
                    Detalhes = tarefas.Detalhes
                };
                db.Tarefas.Add(tarefas_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public Tarefas Read(int Id)
        {
            try
            {
                var tarefas_db = db.Tarefas.Find(Id);
                tarefas_db.DateTarefa = DateTime.Now;
                return tarefas_db;
                
            }
            catch
            {
                return new Tarefas();
            }
        }
        public Tarefas Read(Tarefas tarefas)
        {
            try
            {
                var tarefas_db = db.Tarefas.Find(tarefas.Titulo, tarefas.Detalhes);
                return tarefas_db;
            }catch
            {
                return null;
            }
        }
        public bool Update(PutTarefas tarefas)
        {
            try
            {
                var tarefas_db = db.Tarefas.Find(tarefas.Id);
                {
                    tarefas_db.Titulo = tarefas.Titulo;
                    tarefas_db.Detalhes = tarefas.Detalhes;
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int Id)
        {
            try
            {
                var tarefas_db = db.Tarefas.Find(Id);
                db.Tarefas.Remove(tarefas_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
