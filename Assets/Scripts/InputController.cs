using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    [SerializeField] private Hotbar Hotbar1;
    [SerializeField] private Hotbar Hotbar2;
    [SerializeField] private Hotbar Hotbar3;

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

    void Update()
    {
        _timeSinceGcdStart += Time.deltaTime;
        var isAltDown = Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);
        var isCtrlDown = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
        var isShiftDown = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        var is1Down = Input.GetKey(KeyCode.Alpha1);
        var is2Down = Input.GetKey(KeyCode.Alpha2);
        var is3Down = Input.GetKey(KeyCode.Alpha3);
        var is4Down = Input.GetKey(KeyCode.Alpha4);
        var is5Down = Input.GetKey(KeyCode.Alpha5);
        var is6Down = Input.GetKey(KeyCode.Alpha6);
        var is7Down = Input.GetKey(KeyCode.Alpha7);
        var is8Down = Input.GetKey(KeyCode.Alpha8);
        var is9Down = Input.GetKey(KeyCode.Alpha9);
        var is0Down = Input.GetKey(KeyCode.Alpha0);
        var isMinusDown = Input.GetKey(KeyCode.Minus);
        var isEqualDown = Input.GetKey(KeyCode.Equals);

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
                    DoHotbarSlot(slot.GetAction(), kb.Name, slot.GetCurrentImage());
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
                    DoHotbarSlot(slot.GetAction(), kb.Name, slot.GetCurrentImage());
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
                    DoHotbarSlot(slot.GetAction(), kb.Name, slot.GetCurrentImage());
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
                if (_timeSinceGcdStart >= GCD)
                {
                    _timeSinceGcdStart = 0;
                    Debug.Log(skill.SkillType + ": " + skill.Name);
                    TrainerController.Instance().AddSkillLogEntry(skill.Name, skillIcon);
                }
            }
            else
            {
                Debug.Log(skill.SkillType + ": " + skill.Name);
                TrainerController.Instance().AddSkillLogEntry(skill.Name, skillIcon);
            }
            // todo handle recast time, casttime, available, etc
            // todo kick off gcd/recast circle
        }

    }

    public void SetHotbarSlotSkill(int hotbar, string slotName, Button skill)
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

    IEnumerator GlobalCoolDown()
    {
        yield return new WaitForSeconds(GCD);
    }
}
