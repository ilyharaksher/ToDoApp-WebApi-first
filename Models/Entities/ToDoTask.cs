namespace ToDoApp_WebApi.Models.Entities
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
