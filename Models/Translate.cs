using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ceviri.Models
{

    public class Translate
    {
        public int Id { get; set; }
        public int Support{ get; set; }
        public int TranslatorID { get; set; }
    }
}