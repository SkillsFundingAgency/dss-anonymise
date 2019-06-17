﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NCS.DSS.Anonymise.Annotations;
using NCS.DSS.Anonymise.ReferenceData;
using NCS.DSS.Anonymise.Helpers;

namespace NCS.DSS.Anonymise.Models
{
    public class Outcome : AnonHelper, IAnonymise
    {
        [Display(Description = "Unique identifier of the Outcomes record.")]
        [Example(Description = "b8592ff8-af97-49ad-9fb2-e5c3c717fd85")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public Guid? OutcomeId { get; set; }

        [Display(Description = "Unique identifier of a customer.")]
        [Example(Description = "2730af9c-fc34-4c2b-a905-c4b584b0f379")]
        public Guid? CustomerId { get; set; }

        [Display(Description = "Unique identifier to the related action plan resource.")]
        [Example(Description = "2730af9c-fc34-4c2b-a905-c4b584b0f379")]
        public Guid? ActionPlanId { get; set; }


        [Required]
        [Display(Description = "Unique identifier to the related session resource. " +
                       "This will need to be provided the first time on a Patch Request for V2")]
        [Example(Description = "2730af9c-fc34-4c2b-a905-c4b584b0f379")]
        public Guid? SessionId { get; set; }

        [StringLength(50)]
        [Display(Description = "Identifier supplied by the touchpoint to indicate their subcontractor")]
        [Example(Description = "01234567899876543210")]
        public string SubcontractorId { get; set; }


        [Display(Description = "Outcome Type reference data value   :   " +
                                "1 - Customer Satisfaction,   " +
                                "2 - Career Management,    " +
                                "3 - Sustainable Employment,    " +
                                "4 - Accredited Learning,    " +
                                "5 - Career Progression")]
        [Example(Description = "1")]
        public OutcomeType? OutcomeType { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Description = "Date that an outcome was claimed by the prime contractor.  Only one Outcome of each type is allowed within a 12 month period")]
        [Example(Description = "2018-06-20T21:45:00")]
        public DateTime? OutcomeClaimedDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Description = "Date the primes were notified that the outcome had been achieved by the customer")]
        [Example(Description = "2018-06-20T21:45:00")]
        public DateTime? OutcomeEffectiveDate { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [Display(Description = "Identifier of the touchpoint claiming the outcome.")]
        [Example(Description = "0000000001")]
        public string TouchpointId { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Description = "Date and time of the last modification to the record.")]
        [Example(Description = "2018-06-20T13:45:00")]
        public DateTime? LastModifiedDate { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [Display(Description = "Identifier of the touchpoint who made the last change to the record")]
        [Example(Description = "0000000001")]
        public string LastModifiedTouchpointId { get; set; }

        public void Anonymise()
        {

        }
    }

}
