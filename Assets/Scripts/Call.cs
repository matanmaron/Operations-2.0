using Json;
using System;
using System.Runtime.Serialization;

namespace Operations
{
    [Serializable]
    public class Call
    {
        public SerializableGuid CallGuid = Guid.NewGuid();
        public string Representative;
        public string Contents;
        public DateTime CallDate;
        public DateTime DealEnd;

        public override string ToString()
        {
            return $"{Representative} | {Contents} | {CallDate} | {DealEnd}";
        }
    }
}