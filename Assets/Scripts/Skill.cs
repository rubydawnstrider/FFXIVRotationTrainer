using System;
using System.Xml.Serialization;

[Serializable]
[XmlType("Skill")]
public class Skill 
{
    public string Name { get; set; }
    public JobType Job { get; set; }
    public int Level { get; set; }
    public string Description { get; set; }
    public float RecastTime { get; set; }
    public float AdjustedRecastTime { get; set; }
    public float CastTime { get; set; }
    public TargetType TargetType { get; set; }
    public string IconName { get; set; }
    public string ComboAction { get; set; }
    public SkillType SkillType { get; set; }
    // todo monk skills require form as well
    // todo job guages 
}
