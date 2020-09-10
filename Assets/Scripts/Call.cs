using Json;
using System;
using System.Runtime.Serialization;

namespace Operations.Core
{
    [Serializable]
    public class Call
    {
        public SerializableGuid CallGuid = Guid.NewGuid();
        public string Representative = string.Empty;
        public string Contents = string.Empty;
        public DateTime CallDate = DateTime.Now;
        public DateTime DealEnd = DateTime.Now;
        public bool IsDeleted = false;

        public Call()
        {
            DealEnd = DealEnd.AddYears(1);
        }

        public override string ToString()
        {
            return $"{Representative} | {Contents} | {CallDate.ToShortDateString().StringReverse()} | {DealEnd.ToShortDateString().StringReverse()}";
        }
    }
}