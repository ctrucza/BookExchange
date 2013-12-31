namespace poc.Models
{
    public class Book
    {
        public string Author {get; set;}
        public string Title {get; set;}
        public User SharedBy { get; set; }
    }
}