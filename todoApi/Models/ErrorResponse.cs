namespace todoApi.Models
{
    //When an error occur in our application we can create a model for that error and return it to the client
    public class ErrorResponse
    {
        public string Title { get; set; }   
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
