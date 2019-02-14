using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCS.DSS.Anonymise.Models
{
    public class RequestOptions
    {
        public string SourceEndPoint { get; set; }
        public string SourceKey { get; set; }
        public string TargetEndPoint { get; set; }
        public string TargetKey { get; set; }
        public string TargetPostfix { get; set; }
        public string CopyCustomer { get; set; } = "false";
        public string CopyAddress { get; set; } = "false";
        public string CopyContacts { get; set; } = "false";
        public string CopyActionPlans { get; set; } = "false";
        public string CopyActions { get; set; } = "false";
        public string CopyAddresses { get; set; } = "false";
        public string CopyAdviserDetails { get; set; } = "false";
        public string CopyContactDetails { get; set; } = "false";
        public string CopyCustomers { get; set; } = "false";
        public string CopyDiversityDetails { get; set; } = "false";
        public string CopyGoals { get; set; } = "false";
        public string CopyInteractions { get; set; } = "false";
        public string CopyOutcomes { get; set; } = "false";
        public string CopySessions { get; set; } = "false";
        public string CopySubscriptions { get; set; } = "false";
        public string CopyTransfers { get; set; } = "false";
        public string CopyWebChats { get; set; } = "false";

    }
}
