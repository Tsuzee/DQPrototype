using UnityEngine;
using System.Collections;

/// <summary>
/// Skills used in game.
/// Defines the properites of a skill
/// </summary>
public class Skill : MonoBehaviour {

    //private variables
    private string skillName;
    private SkillType type;
    private bool learned;
    private bool ableToLearn;

    //public accessors
    public enum SkillType { MeleeWeapon, RangedWeapon, ExtoicWeapon, StandardArmor, HeaveyArmor, CraftItem, CraftWeapon, CraftArmor};
    public string SkillName
    {
        get { return skillName; }
    }
    public bool Learned
    {
        get { return learned; }
    }
    public bool AbleToLearn
    {
        get { return ableToLearn; }
    }
    public SkillType Type
    {
        get { return type; }
    }

    /// <summary>
    /// Setup a skill. All skills are not learned by default.
    /// </summary>
    /// <param name="setName">Name of skill</param>
    /// <param name="setType">Type of skill</param>
    /// <param name="setAbleToLearn">Can the player learn the skill</param>
    Skill(string setName, SkillType setType, bool setAbleToLearn)
    {
        skillName = setName;
        type = setType;
        learned = false;
        ableToLearn = setAbleToLearn;
    }//end of skill constructor
}//end skill class
