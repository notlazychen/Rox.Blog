namespace BlazorBlog.Data
{
    public class Tag
    {
        public int Id { get; set; }
        public string Text { get; set; } = "";

        public virtual List<Post> Posts { get; set; } = new List<Post>();
    }
}