namespace WebToDo21.Models
{
    class TodoCard
    {
        public int CardId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}