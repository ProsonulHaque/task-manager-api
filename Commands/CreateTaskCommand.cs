namespace task_manager_api.Requests
{
    public class CreateTaskCommand
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateOnly? DueDate { get; set; }
        public int StatusId { get; set; }
    }
}
