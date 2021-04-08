using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ceviri.Models
{

    public class Translate
    {
        public int TranslateId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        
        public int TranslatorId { get; set; }
        public Translator Translator { get; set; }
        public ICollection<Support> Supports { get; set; }



    }
}