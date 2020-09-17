using Json;
using System;

namespace Operations.Core
{
    [Serializable]
    public class Call
    {
        public SerializableGuid CallGuid = Guid.NewGuid();
        public string Representative = string.Empty;
        public string Contents = string.Empty;
        public long CallDateTicks = DateTime.Now.Ticks;
        public long DealEndTicks = DateTime.Now.Ticks;
        public bool IsDeleted = false;
        
        public Call()
        {
            DealEndTicks = new DateTime(DealEndTicks).AddYears(1).Ticks;
        }

        public override string ToString()
        {
            return $"{Representative} | {Contents} | {new DateTime(DealEndTicks).ToShortDateString().StringReverse()} | {new DateTime(CallDateTicks).ToShortDateString().StringReverse()}";
        }
    }
}