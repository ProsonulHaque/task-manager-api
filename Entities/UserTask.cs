namespace task_manager_api.Entities
{
    public class UserTask
    {
        public Guid UserTaskId { get; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateOnly? DueDate { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; }
        public DateTime CreateDateUtc { get; set; }
    }
}
