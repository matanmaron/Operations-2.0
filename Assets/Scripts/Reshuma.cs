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
        public string Company;
        public string Type;
        public string PhoneNumber;
        public List<Call> Calls;
        public bool IsDeleted;

        public override string ToString()
        {
            return $"{Company} | {Type} | {PhoneNumber.ToString().Reverse()}";
        }
    }
}