using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public float GCD = 2.5f;
    private float _timeSinceGcdStart;

    private static InputController _instance;
    public static InputController Instance()
    {
        if (_instance == null)
        {
            _instance = new InputController();
        }
        return _instance;
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

    }


    #region defaults
    //for now.replace with true manager later
    IList<Keybind> Hotbar1 = new List<Keybind> {

        new Keybind { Name = "Hotbar1Slot1", KeyCode = KeyCode.Alpha1, Modifier = KeyModifier.None }, 
        new Keybind { Name = "Hotbar1Slot2", KeyCode = KeyCode.Alpha2, Modifier = KeyModifier.None },
        new Keybind { Name = "Hotbar1Slot3", KeyCode = KeyCode.Alpha3, Modifier = KeyModifier.None },
        new Keybind { Name = "Hotbar1Slot4", KeyCode = KeyCode.Alpha4, Modifier = KeyModifier.None },
        new Keybind { Name = "Hotbar1Slot5", KeyCode = KeyCode.Alpha5, Modifier = KeyModifier.None },
        new Keybind { Name = "Hotbar1Slot6", KeyCode = KeyCode.Alpha6, Modifier = KeyModifier.None },
        new Keybind { Name = "Hotbar1Slot7", KeyCode = KeyCode.Alpha7, Modifier = KeyModifier.None },
        new Keybind { Name = "Hotbar1Slot8", KeyCode = KeyCode.Alpha8, Modifier = KeyModifier.None },
        new Keybind { Name = "Hotbar1Slot9", KeyCode = KeyCode.Alpha9, Modifier = KeyModifier.None },
        new Keybind { Name = "Hotbar1Slot10", KeyCode = KeyCode.Alpha0, Modifier = KeyModifier.None },
        new Keybind { Name = "Hotbar1Slot11", KeyCode = KeyCode.Minus, Modifier = KeyModifier.None },
        new Keybind { Name = "Hotbar1Slot12", KeyCode = KeyCode.Equals, Modifier = KeyModifier.None }
    };
    //private Keybind Hotbar1Slot1  = new Keybind { KeyCode = KeyCode.Alpha1, Modifier = KeyModifier.None };
    //private Keybind Hotbar1Slot2  = new Keybind { KeyCode = KeyCode.Alpha2, Modifier = KeyModifier.None };
    //private Keybind Hotbar1Slot3  = new Keybind { KeyCode = KeyCode.Alpha3, Modifier = KeyModifier.None };
    //private Keybind Hotbar1Slot4  = new Keybind { KeyCode = KeyCode.Alpha4, Modifier = KeyModifier.None };
    //private Keybind Hotbar1Slot5  = new Keybind { KeyCode = KeyCode.Alpha5, Modifier = KeyModifier.None };
    //private Keybind Hotbar1Slot6  = new Keybind { KeyCode = KeyCode.Alpha6, Modifier = KeyModifier.None };
    //private Keybind Hotbar1Slot7  = new Keybind { KeyCode = KeyCode.Alpha7, Modifier = KeyModifier.None };
    //private Keybind Hotbar1Slot8  = new Keybind { KeyCode = KeyCode.Alpha8, Modifier = KeyModifier.None };
    //private Keybind Hotbar1Slot9  = new Keybind { KeyCode = KeyCode.Alpha9, Modifier = KeyModifier.None };
    //private Keybind Hotbar1Slot10 = new Keybind { KeyCode = KeyCode.Alpha0, Modifier = KeyModifier.None };
    //private Keybind Hotbar1Slot11 = new Keybind { KeyCode = KeyCode.Minus, Modifier = KeyModifier.None };
    //private Keybind Hotbar1Slot12 = new Keybind { KeyCode = KeyCode.Equals, Modifier = KeyModifier.None };
    #endregion defaults


    void Update()
    {
        _timeSinceGcdStart += Time.deltaTime;
        foreach (var kb in Hotbar1)
        {
            if (Input.GetKeyDown(kb.KeyCode))
            {
                if (kb.Modifier.HasFlag(KeyModifier.None) ||
                    ( kb.Modifier.HasFlag(KeyModifier.Alt) && (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) ) ||
                    ( kb.Modifier.HasFlag(KeyModifier.Shift) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) ) ||
                    ( kb.Modifier.HasFlag(KeyModifier.Control) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) ) )
                {
                    DoHotbarSlot(kb.Skill, kb.Name);
                    //GetType().GetMethod("Do" + kb.Name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Invoke(this, new[] { kb.Skill });
                    break;
                }
            }
        }
    }

    #region hotbar1
    void DoHotbarSlot(Skill skill, string name)
    {
        Debug.Log(name + " Press");
        if (skill != null)
        {
            if (skill.SkillType != SkillType.Ability) // is a GCD skill
            {
                if (_timeSinceGcdStart >= GCD)
                {
                    _timeSinceGcdStart = 0;
                    Debug.Log(skill.SkillType + ": " + skill.Name);
                }
            }
            else
            {
                Debug.Log(skill.SkillType + ": " + skill.Name);
            }
            // todo handle recast time, casttime, available, etc
            // todo kick off gcd, recast circle
        }

    }
    private void DoHotbar1Slot1(Skill skill)
    {
        Debug.Log("H1S1 Press");
        if (skill != null)
        {
            if (skill.SkillType != SkillType.Ability) // is a GCD skill
            {
                if (_timeSinceGcdStart >= GCD)
                {
                    _timeSinceGcdStart = 0;
                    Debug.Log(skill.SkillType + ": " + skill.Name);
                }
            }
            else
            {
                Debug.Log(skill.SkillType + ": " + skill.Name);
            }
            // todo handle recast time, casttime, available, etc
            // todo kick off gcd, recast circle
        }
    }
    private void DoHotbar1Slot2(Skill skill)
    {
        Debug.Log("H1S2 Press");
        if (skill != null)
        {
            Debug.Log("Action: " + skill.Name);
            // todo handle recast time, casttime, available, etc
            // todo kick off gcd, recast circle
        }
    }
    private void DoHotbar1Slot3(Skill skill)
    {
        Debug.Log("H1S3 Press");
        if (skill != null)
        {
            Debug.Log("Action: " + skill.Name);
            // todo handle recast time, casttime, available, etc
            // todo kick off gcd, recast circle
        }
    }
    private void DoHotbar1Slot4(Skill skill)
    {
        Debug.Log("H1S4 Press");
        if (skill != null)
        {
            Debug.Log("Action: " + skill.Name);
            // todo handle recast time, casttime, available, etc
            // todo kick off gcd, recast circle
        }
    }
    private void DoHotbar1Slot5(Skill skill)
    {
        Debug.Log("H1S5 Press");
        if (skill != null)
        {
            Debug.Log("Action: " + skill.Name);
            // todo handle recast time, casttime, available, etc
            // todo kick off gcd, recast circle
        }
    }
    private void DoHotbar1Slot6(Skill skill)
    {
        Debug.Log("H1S6 Press");
        if (skill != null)
        {
            Debug.Log("Action: " + skill.Name);
            // todo handle recast time, casttime, available, etc
            // todo kick off gcd, recast circle
        }
    }
    private void DoHotbar1Slot7(Skill skill)
    {
        Debug.Log("H1S7 Press");
        if (skill != null)
        {
            Debug.Log("Action: " + skill.Name);
            // todo handle recast time, casttime, available, etc
            // todo kick off gcd, recast circle
        }
    }
    private void DoHotbar1Slot8(Skill skill)
    {
        Debug.Log("H1S8 Press");
        if (skill != null)
        {
            Debug.Log("Action: " + skill.Name);
            // todo handle recast time, casttime, available, etc
            // todo kick off gcd, recast circle
        }
    }
    private void DoHotbar1Slot9(Skill skill)
    {
        Debug.Log("H1S9 Press");
        if (skill != null)
        {
            Debug.Log("Action: " + skill.Name);
            // todo handle recast time, casttime, available, etc
            // todo kick off gcd, recast circle
        }
    }
    private void DoHotbar1Slot10(Skill skill)
    {
        Debug.Log("H1S10 Press");
        if (skill != null)
        {
            Debug.Log("Action: " + skill.Name);
            // todo handle recast time, casttime, available, etc
            // todo kick off gcd, recast circle
        }
    }
    private void DoHotbar1Slot11(Skill skill)
    {
        Debug.Log("H1S11 Press");
        if (skill != null)
        {
            Debug.Log("Action: " + skill.Name);
            // todo handle recast time, casttime, available, etc
            // todo kick off gcd, recast circle
        }
    }
    private void DoHotbar1Slot12(Skill skill)
    {
        Debug.Log("H1S12 Press");
        if (skill != null)
        {
            Debug.Log("Action: " + skill.Name);
            // todo handle recast time, casttime, available, etc
            // todo kick off gcd, recast circle
        }
    }
    #endregion hotbar1

    public void SetHotbarSlotSkill(string slotName, Skill skill)
    {
        foreach(var slot in Hotbar1)
        {
            if (slot.Name == slotName)
            {
                slot.Skill = skill;
                break;
            }
        }
    }

    IEnumerator GlobalCoolDown()
    {
        yield return new WaitForSeconds(GCD);
    }
}
