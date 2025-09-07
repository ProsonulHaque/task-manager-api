namespace task_manager_api.Entities
{
    public class Status
    {
        public int StatusId { get; }
        public string Name { get; set; }
        public List<UserTask>? UserTasks { get; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    }
}
