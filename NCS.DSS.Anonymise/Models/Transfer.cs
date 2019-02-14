﻿using System;
using System.ComponentModel.DataAnnotations;
using NCS.DSS.Anonymise.Annotations;
using NCS.DSS.Anonymise.ReferenceData;
using NCS.DSS.Anonymise.Helpers;

namespace NCS.DSS.Anonymise.Models
{
    public class Transfer : AnonHelper, IAnonymise
    {
        [Display(Description = "Unique identifier of the transfer record.")]
        [Example(Description = "b8592ff8-af97-49ad-9fb2-e5c3c717fd85")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public Guid? TransferId { get; set; }

        [Display(Description = "Unique identifier of a customer.")]
        [Example(Description = "2730af9c-fc34-4c2b-a905-c4b584b0f379")]
        public Guid CustomerId { get; set; }

        [Display(Description = "Unique identifier for the related interaction record.")]
        [Example(Description = "2730af9c-fc34-4c2b-a905-c4b584b0f379")]
        public Guid? InteractionId { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [Display(Description = "Identifier of the touchpoint who made the last change to the record")]
        [Example(Description = "0000000001")]
        public string OriginatingTouchpointId { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        [Display(Description = "Identifier of the touchpoint who made the last change to the record")]
        [Example(Description = "0000000001")]
        public string TargetTouchpointId { get; set; }

        [Required]
        [StringLength(2000)]
        [Display(Description = "Context of the transfer.")]
        [Example(Description = "this is some text")]
        public string Context { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Description = "Date and time the transfer request was made.")]
        [Example(Description = "2018-06-20T13:45:00")]
        public DateTime? DateandTimeOfTransfer { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Description = "Date and time the transfer request was accepted by the target touchpoint.")]
        [Example(Description = "2018-06-21T08:45:00")]
        public DateTime? DateandTimeofTransferAccepted { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Description = "Date and time the customer wants to be called back.")]
        [Example(Description = "2018-06-27T08:45:00")]
        public DateTime? RequestedCallbackTime { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Description = "Date and time the transfer was acted upon and the customer was contacted.")]
        [Example(Description = "2018-06-26T08:45:00")]
        public DateTime? ActualCallbackTime { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Description = "Date and time of the last modification to the record.")]
        [Example(Description = "2018-06-28T08:00:00")]
        public DateTime? LastModifiedDate { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [Display(Description = "Identifier of the touchpoint who made the last change to the record")]
        [Example(Description = "0000000001")]
        public string LastModifiedTouchpointId { get; set; }

  
        public void Anonymise()
        {
            Context = RandomiseText(Context);
        }

    }
}

