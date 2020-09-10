using Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Operations.Core
{
    [Serializable]
    [DataContract]
    public class Reshuma
    {
        public SerializableGuid ReshumaGuid = Guid.NewGuid();
        public string Company = string.Empty;
        public string Type = string.Empty;
        public string PhoneNumber = string.Empty;
        public List<Call> Calls = new List<Call>();
        public bool IsDeleted = false;

        public override string ToString()
        {
            return $"{Company} | {Type} | {PhoneNumber.StringReverse()}";
        }
    }
}