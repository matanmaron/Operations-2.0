using System;

namespace Operations
{
    [Serializable]
    public class Call
    {
        public Guid CallGuid { get; set; }
        public string Representative { get; set; }
        public string Contents { get; set; }
        public DateTime CallDate { get; set; }
        public DateTime DealEnd { get; set; }
    }
}