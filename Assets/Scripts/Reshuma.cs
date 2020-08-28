using Managers;
using System;
using System.Collections.Generic;

namespace Operations
{
    [Serializable]
    public class Reshuma
    {
        public int ReshumaGuid { get; set; }
        public string Company { get; set; }
        public string Type { get; set; }
        public string PhoneNumber { get; set; }
        public List<Call> Calls { get; set; }

    }
}