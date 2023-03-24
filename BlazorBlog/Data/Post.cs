namespace BlazorBlog.Data
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public DateTime PublishAt { get; set; } = DateTime.Now;

        public int? AuthorId { get; set; }
        public virtual Author? Author { get; set; }

        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public virtual List<Tag> Tags { get; set; } = new List<Tag>();
    }
}