namespace VStore.Models
{
    public class Video
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public Genre Genre { get; set; }

    }
}
