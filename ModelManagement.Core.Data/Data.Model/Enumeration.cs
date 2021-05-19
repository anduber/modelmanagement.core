using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class Enumeration : Entity
    {
        public Enumeration()
        {
            Enumeration_Complexion = new List<PhysicalInformation>();
            Enumeration_JobPostPaymentMethodEnum = new List<JobPost>();
            Enumeration_AgentJobEnum = new List<JobPost>();
            PersonalInformationExperiance_PersonalInformation = new List<PersonalInformation>();
            Enumeration_HairColor = new List<PhysicalInformation>();
            Enumeration_SkillLevel = new List<Skill>();
            Enumeration_DurationOfContract = new List<JobPost>();
            Enumeration_BodyTatoo = new List<PhysicalInformation>();
        }
        public string EnumerationId { get; set; }
        public string EnumerationTypeId { get; set; }
        public string Description { get; set; }
        public string EnumCode { get; set; }
        public string SequenceId { get; set; }
        public string IsActive { get; set; }
        public virtual EnumerationType EnumerationType { get; set; }
        public virtual List<PhysicalInformation> Enumeration_Complexion { get; set; }
        public virtual List<PhysicalInformation> Enumeration_HairColor { get; set; }
        public virtual List<PhysicalInformation> Enumeration_BodyTatoo { get; set; }
        public virtual List<JobPost> Enumeration_JobPostPaymentMethodEnum { get; set; }
        public virtual List<JobPost> Enumeration_AgentJobEnum { get; set; }
        public virtual List<PersonalInformation> PersonalInformationExperiance_PersonalInformation { get; set; }
        public virtual List<Skill> Enumeration_SkillLevel { get; set; }
        public virtual List<JobPost> Enumeration_DurationOfContract { get; set; }

    }
}
