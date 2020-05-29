using Dapper.Contrib.Extensions;

namespace WebApiDapper.Models
{
    [Table("todos")]
    public class Todos
    {
        public Todos()
        {
        }

        public Todos(string description, bool done)
        {
            Description = description;
            Done = done;
        }

        public Todos(int id, string description, bool done)
        {
            Id = id;
            Description = description;
            Done = done;
        }

        [Key()]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
