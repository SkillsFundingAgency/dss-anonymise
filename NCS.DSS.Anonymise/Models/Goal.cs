using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NCS.DSS.Anonymise.Annotations;
using NCS.DSS.Anonymise.ReferenceData;
using NCS.DSS.Anonymise.Helpers;

namespace NCS.DSS.Anonymise.Models
{

    public class Goal : AnonHelper, IAnonymise
    {
        [Display(Description = "Unique identifier for a goal record")]
        [Example(Description = "b8592ff8-af97-49ad-9fb2-e5c3c717fd85")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public Guid? GoalId { get; set; }

        [Display(Description = "Unique identifier for a subscription record. ")]
        [Example(Description = "b8592ff8-af97-49ad-9fb2-e5c3c717fd85")]
        public Guid? CustomerId { get; set; }

        [Display(Description = "Unique identifier for the customers goal plan.")]
        [Example(Description = "2730af9c-fc34-4c2b-a905-c4b584b0f379")]
        public Guid? ActionPlanId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Description = "Date and time the goal was captured or agreed with the customer")]
        [Example(Description = "2018-06-21T11:31:00")]
        public DateTime? DateGoalCaptured { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Description = "Date the customer aims to complete their goal by.")]
        [Example(Description = "2018-06-23T12:01:00")]
        public DateTime? DateGoalShouldBeCompletedBy { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Description = "Date the customer actually achieved their goal")]
        [Example(Description = "2018-06-22T19:53:00")]
        public DateTime? DateGoalAchieved { get; set; }

        [Required]
        [StringLength(2000)]
        [Display(Description = "Details of the customer goal")]
        [Example(Description = "this is some text")]
        public string GoalSummary { get; set; }

        [Required]
        [Display(Description = " GoalType reference data   :   " +
                                    "1 - Skills,  " +
                                    "2 - Work,  " +
                                    "3 - Learning,  " +
                                    "99 - Other")]
        [Example(Description = "1")]
        public GoalType? GoalType { get; set; }

        [Display(Description = "Goal status reference data   :   " +
                                    "1 - In progress,  " +
                                    "2 - Achieved,  " +
                                    "99 - No longer relevant")]
        [Example(Description = "2")]
        public GoalStatus? GoalStatus { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Description = "Date and time of the last modification to the record.")]
        [Example(Description = "2018-06-24T01:01:00")]
        public DateTime? LastModifiedDate { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [Display(Description = "Identifier of the touchpoint who made the last change to the record")]
        [Example(Description = "0000000001")]
        public string LastModifiedBy { get; set; }

        public void Anonymise()
        {
            GoalSummary = RandomiseText(GoalSummary);
        }
    }

}
