using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficViolationModel
{
    public class SCModel
    {
        public string ViolationAddress { get; set; }
        public string ViolationDateTime { get; set; }
        public string ViolationAmount { get; set; }
        public string ViolationScore { get; set; }
    }
    public class ViolationModel
    {
        public string CarNumber { get; set; }
        public string ViolationAddress { get; set; }
        public string ViolationDateTime { get; set; }
        public int ViolationAmount { get; set; }
        public int ViolationScore { get; set; }
        public string ViolationContent { get; set; }
        public string ViolationStatus { get; set; }
        public DateTime Created_Time { get; set; }
    }
    public class SCParams
    {
        public string CarNumber { get; set; }
        public string CarFrame { get; set; }
    }
    public class CarInfoModel
    {
        public string CarNumber { get; set; }
        public string CarFrame { get; set; }
        public string CarOwner { get; set; }
        public DateTime RefreshDate_C { get; set; }
        public DateTime RefreshDate_U { get; set; }
    }
}
