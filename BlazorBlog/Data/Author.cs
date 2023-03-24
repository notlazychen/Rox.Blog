namespace BlazorBlog.Data
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";

        public DateTime JoinAt { get; set; } = DateTime.Now;
    }
}