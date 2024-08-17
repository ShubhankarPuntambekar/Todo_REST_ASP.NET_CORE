using System.ComponentModel.DataAnnotations;

namespace todoApi.Models
{
    public class Todo
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public bool IsComplete { get; set; }

        public DateTime DueDate { get; set; }

        public int Priority {  get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Todo()
        {
            IsComplete = false; 
        }

    }
}
