﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class PersonalInformation : Entity
    {
        public PersonalInformation()
        {
            ContactInformations_PersonId = new List<ContactInformation>();
            Uploadables_PersonId = new List<Uploadable>();
            Trainings_PersonId = new List<Training>();
            ModelingExperiances = new List<ModelingExperiance>();
            Skills = new List<Skill>();
            Categories_PersonId = new List<Category>();
        }
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string MaritialStatusEnumId  { get; set; }
        public string GeoId { get; set; }
        public string CountryGeoId { get; set; }
        public string CityGeoId { get; set; }
        public string ExperienceEnumId { get; set; }
        public string Description { get; set; }
        public virtual Adderss Adderss { get; set; }
        public virtual PhysicalInformation PersonId_PhysicalInformation { get; set; }
        public virtual List<ContactInformation> ContactInformations_PersonId { get; set; }
        public virtual List<Category> Categories_PersonId { get; set; }
        public virtual List<Uploadable> Uploadables_PersonId { get; set; }
        public virtual List<Training> Trainings_PersonId { get; set; }
        public virtual List<ModelingExperiance> ModelingExperiances { get; set; }
        public virtual List<Skill> Skills { get; set; }
        public virtual List<WorkExperiance> WorkExperiances { get; set; }
        public virtual User PersonId_User { get; set; }
        public virtual UserLogin UserLoginId_UserLogin { get; set; }
        public virtual Geo GeoId_Geo { get; set; }
        public virtual Geo CountryGeoId_Geo { get; set; }
        public virtual Geo CityGeoId_Geo { get; set; }
        public virtual Enumeration ExperienceEnumId_Enumeration { get; set; }
    }
}
