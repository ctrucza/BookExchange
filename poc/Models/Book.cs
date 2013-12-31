namespace poc.Models
{
    public class Book
    {
        public string Author;
        public string Title;
        public User SharedBy { get; set; }
    }
}