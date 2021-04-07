namespace Ceviri.Models {
    public class Book {
        public int ID { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Publisher { get; set; }
        public string Year { get; set; }

        public int TranslateID { get; set; }

    }
}