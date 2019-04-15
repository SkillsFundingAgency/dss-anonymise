using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCS.DSS.Anonymise.ReferenceData;

namespace NCS.DSS.Anonymise.Models
{
    public interface IAnonymise

    {
        void SetRandomSeed(Random randSeed);
        void Anonymise();
        string LastModifiedTouchpointId { get; set; }
    }
}
