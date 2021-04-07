namespace Ceviri.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Translator
    {
        [Key]
        public int TranslatorID { get; set; }
        public string FirstMidName { get; set; }
        public string LastName { get; set; }
    }
}