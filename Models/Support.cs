using Ceviri.Models;

namespace Ceviri
{
    public class Support
    {
        public int SupportId { get; set; }
        public decimal Bounty { get; set; }
        public int SupporterId { get; set; }
        public Supporter Supporter { get; set; }
        public int TranslateId { get; set; }
        public Translate Translate { get; set; }
    }
}