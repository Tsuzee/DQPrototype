using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// Player Skill Tree. Contains all of the skills and handles their active states.
/// </summary>
public class SkillTree : MonoBehaviour {

    //Holds values for the trees
    private Dictionary<Skill.SkillType, int> tree;
    private List<Skill> skills;

    /// <summary>
    /// Create a new skill tree.
    /// </summary>
    public SkillTree()
    {
        tree = new Dictionary<Skill.SkillType, int>();
        skills = new List<Skill>();
    }//end constructor

    /// <summary>
    /// Add types of skills to the skill tree.
    /// </summary>
    /// <param name="type">Type of skill</param>
    public void AddSkillType(Skill.SkillType type)
    {
        tree.Add(type, 0);
    }//end add skill type

    /// <summary>
    /// Add skills to a list.
    /// </summary>
    /// <param name="skill">Skill</param>
    public void AddSkill(Skill skill)
    {
        skills.Add(skill);
    }//end add skill

    /// <summary>
    /// Return the current skill tree level for a skill type.
    /// </summary>
    /// <returns>Returns the Dictionary(Skill.SkillType, int) tree</returns>
    public Dictionary<Skill.SkillType, int> GetSkillTree()
    {
        return tree;
    }//end get tree

    /// <summary>
    /// Unlock a skill
    /// </summary>
    /// <param name="skill">Skill to try and unlock</param>
    /// <returns>Returns true if unlock was successful</returns>
    public bool Unlock(Skill skill)
    {
        if(skill.AbleToLearn)
        {
            skill.Learned = true;
            tree[skill.Type]++;
            foreach(Skill next in skills)
            {
                if(next.Type == skill.Type && next.Number == (skill.Number + 1) )
                {
                    next.AbleToLearn = true;
                }
            }//end for
        }//end if
        return true;
    }//end unlock skill

}//end skill tree class