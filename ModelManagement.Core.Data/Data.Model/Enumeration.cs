using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class Enumeration : CommonEntity
    {
        public Enumeration()
        {
            MaritialStatus_PersonalInformation = new List<PersonalInformation>();
            HeightEnumId_PhysicalInformation = new List<PhysicalInformation>();
            WeightEnumId_PhysicalInformation = new List<PhysicalInformation>();
            Enumeration_JobPostPaymentMethodEnum = new List<JobPost>();
            Enumeration_AgentJobEnum = new List<JobPost>();
        }
        public string EnumerationId { get; set; }
        public string EnumerationTypeId { get; set; }
        public string Description { get; set; }
        public virtual EnumerationType EnumerationType { get; set; }
        public virtual List<PersonalInformation> MaritialStatus_PersonalInformation { get; set; }
        public virtual List<PhysicalInformation> HeightEnumId_PhysicalInformation { get; set; }
        public virtual List<PhysicalInformation> WeightEnumId_PhysicalInformation { get; set; }
        public virtual List<JobPost> Enumeration_JobPostPaymentMethodEnum { get; set; }
        public virtual List<JobPost> Enumeration_AgentJobEnum { get; set; }
    }
}
