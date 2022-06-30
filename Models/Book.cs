namespace Bookstore.Models
{
    public class Book
    {
     /// <summary>
     /// Unique id of the book
     /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of the book
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Describes the subjetct and summary of the book
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The author of the book
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Contains link or path where the cover image is saved
        /// </summary>
        public string? CoverImage { get; set; }

        /// <summary>
        /// Price of the book in Canadian Dollars
        /// </summary>
        public double? Price { get; set; }
    }
}
