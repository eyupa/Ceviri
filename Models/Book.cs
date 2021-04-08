using System.Collections.Generic;

namespace Ceviri.Models {
    public class Book {
        public int BookId { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Publisher { get; set; }
        public string Year { get; set; }
        public ICollection<Translate> Translates { get; set; }
    }
}