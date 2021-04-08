    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    namespace Ceviri.Models
    {
    public class Supporter
    {
        public int SupporterId { get; set; }
        public string FirstMidName { get; set; }
        public string LastName { get; set; }

        public ICollection<Support> Supports { get; set; }
    }
}