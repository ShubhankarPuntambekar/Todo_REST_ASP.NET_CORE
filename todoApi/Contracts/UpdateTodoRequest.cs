using System.ComponentModel.DataAnnotations;

namespace todoApi.Contracts
{
    public class UpdateTodoRequest
    {
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        //Is a nullable property
        public bool? IsComplete { get; set; }

        //Is a nullable property
        public DateTime? DudDate { get; set; }

        [Range(1,5)]
        public int? Priority { get; set; }

        public UpdateTodoRequest()

        {
            IsComplete = false; 
        }
    }
}
