namespace FluentValidationTest.Models
{
    public class TaskItem
    {
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool RemindMe { get; set; }
        public int? ReminderMinutesBeforeDue { get; set; }
        public List<string> SubItems { get; set; }
    }
}
