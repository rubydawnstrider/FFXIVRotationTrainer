using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    [SerializeField] private Hotbar Hotbar1;
    [SerializeField] private Hotbar Hotbar2;
    [SerializeField] private Hotbar Hotbar3;

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

    void Update()
    {
        _timeSinceGcdStart += Time.deltaTime;

        foreach(var slot in Hotbar1.GetHotbarSlots())
        {
            if (!slot.HasAction())
                continue;

            var kb = slot.GetKeybind();
            if (Input.GetKeyDown(kb.KeyCode))
            {
                if ((!kb.Modifier.HasFlag(KeyModifier.Alt) && !kb.Modifier.HasFlag(KeyModifier.Control) && !kb.Modifier.HasFlag(KeyModifier.Shift) &&
                        !Input.GetKey(KeyCode.LeftAlt) && !Input.GetKey(KeyCode.RightAlt) && !Input.GetKey(KeyCode.LeftShift) &&
                        !Input.GetKey(KeyCode.RightShift) && !Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl)) ||
                    (kb.Modifier.HasFlag(KeyModifier.Alt) && (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))) ||
                    (kb.Modifier.HasFlag(KeyModifier.Shift) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))) ||
                    (kb.Modifier.HasFlag(KeyModifier.Control) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))))
                {
                    //DoHotbarSlot(slot.GetAction(), kb.Name, slot.GetCurrentImage());
                    switch (slot.GetAction().SkillType)
                    {
                        case SkillType.Ability:
                            slot.GetComponentInChildren<AbilitySkill>().TriggerSkill();
                            break;
                        case SkillType.Weaponskill:
                            slot.GetComponentInChildren<WeaponSkill>().TriggerSkill();
                            break;
                        case SkillType.Spell:
                            slot.GetComponentInChildren<SpellSkill>().TriggerSkill();
                            break;
                    }
                    break;
                }
            }
        }
        foreach(var slot in Hotbar2.GetHotbarSlots())
        {
            if (!slot.HasAction())
                continue;

            var kb = slot.GetKeybind();
            if (Input.GetKeyDown(kb.KeyCode))
            {
                if ((!kb.Modifier.HasFlag(KeyModifier.Alt) && !kb.Modifier.HasFlag(KeyModifier.Control) && !kb.Modifier.HasFlag(KeyModifier.Shift) &&
                        !Input.GetKey(KeyCode.LeftAlt) && !Input.GetKey(KeyCode.RightAlt) && !Input.GetKey(KeyCode.LeftShift) &&
                        !Input.GetKey(KeyCode.RightShift) && !Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl)) ||
                    (kb.Modifier.HasFlag(KeyModifier.Alt) && (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))) ||
                    (kb.Modifier.HasFlag(KeyModifier.Shift) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))) ||
                    (kb.Modifier.HasFlag(KeyModifier.Control) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))))
                {
                    //DoHotbarSlot(slot.GetAction(), kb.Name, slot.GetCurrentImage());
                    switch (slot.GetAction().SkillType)
                    {
                        case SkillType.Ability:
                            slot.GetComponentInChildren<AbilitySkill>().TriggerSkill();
                            break;
                        case SkillType.Weaponskill:
                            slot.GetComponentInChildren<WeaponSkill>().TriggerSkill();
                            break;
                        case SkillType.Spell:
                            slot.GetComponentInChildren<SpellSkill>().TriggerSkill();
                            break;
                    }
                    break;
                }
            }
        }
        foreach(var slot in Hotbar3.GetHotbarSlots())
        {
            if (!slot.HasAction())
                continue;

            var kb = slot.GetKeybind();
            if (Input.GetKeyDown(kb.KeyCode))
            {
                if ( (!kb.Modifier.HasFlag(KeyModifier.Alt) && !kb.Modifier.HasFlag(KeyModifier.Control) && !kb.Modifier.HasFlag(KeyModifier.Shift) &&
                        !Input.GetKey(KeyCode.LeftAlt) && !Input.GetKey(KeyCode.RightAlt) && !Input.GetKey(KeyCode.LeftShift) && 
                        !Input.GetKey(KeyCode.RightShift) && !Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl) ) ||
                    ( kb.Modifier.HasFlag(KeyModifier.Alt) && (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) ) ||
                    ( kb.Modifier.HasFlag(KeyModifier.Shift) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) ) ||
                    ( kb.Modifier.HasFlag(KeyModifier.Control) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) ) )
                {
                    //DoHotbarSlot(slot.GetAction(), kb.Name, slot.GetCurrentImage());
                    switch (slot.GetAction().SkillType)
                    {
                        case SkillType.Ability:
                            slot.GetComponentInChildren<AbilitySkill>().TriggerSkill();
                            break;
                        case SkillType.Weaponskill:
                            slot.GetComponentInChildren<WeaponSkill>().TriggerSkill();
                            break;
                        case SkillType.Spell:
                            slot.GetComponentInChildren<SpellSkill>().TriggerSkill();
                            break;
                    }
                    break;
                }
            }
        }
    }

    void DoHotbarSlot(Skill skill, string name, Sprite skillIcon)
    {
        Debug.Log(name + " Press");
        if (skill != null)
        {

            if (skill.SkillType != SkillType.Ability) // is a GCD skill
            {
                if (_timeSinceGcdStart >= TrainerController.GcdTime)
                {
                    _timeSinceGcdStart = 0;
                    Debug.Log(skill.SkillType + ": " + skill.Name);
                    TrainerController.Instance.AddSkillLogEntry(skill.Name, skillIcon);
                }
            }
            else
            {
                Debug.Log(skill.SkillType + ": " + skill.Name);
                TrainerController.Instance.AddSkillLogEntry(skill.Name, skillIcon);
            }
            // todo handle recast time, casttime, available, etc
            // todo kick off gcd/recast circle
        }

    }

    public void SetHotbarSlotSkill(int hotbar, string slotName, GameObject skill)
    {
        Hotbar hb = null;
        switch(hotbar)
        {
            case 1:
                hb = Hotbar1;
                break;
            case 2:
                hb = Hotbar2;
                break;
            case 3:
                hb = Hotbar3;
                break;
            default:
                Debug.LogError("Attempt to slot invalid hotbar (" + hotbar + ")");
                throw new ArgumentException("invalid hotbar number", "hotbar");
        }

        foreach(var slot in hb.GetHotbarSlots())
        {
            if (slot.gameObject.name == slotName)
            {
                slot.SetAction(skill);
                break;
            }
        }
    }
}
