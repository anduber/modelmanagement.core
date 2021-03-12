namespace ModelManagement.Core.Data.Data.Model
{
    public class Skill : Entity
    {
        public string SkillId { get; set; }
        public string SkillTypeId { get; set; }
        public string SkillLevelEnumId { get; set; }
        public string PersonId { get; set; }
        public string SkillInfo { get; set; }
        public virtual PersonalInformation PersonalInformation { get; set; }
        public virtual SkillType SkillType { get; set; }
        public virtual Enumeration SkillIdLevel_Enumeration{ get; set; }
    }
}
