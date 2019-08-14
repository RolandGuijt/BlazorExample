using System;
using Google.Protobuf.WellKnownTypes;

namespace RpcApi
{
    public partial class Conference
    {
        public DateTime StartDate
        {
            get
            {
                return Start.ToDateTime();
            }
            set
            {
                Start = Timestamp.FromDateTime(value.ToUniversalTime());
            }
        }
    }
}
