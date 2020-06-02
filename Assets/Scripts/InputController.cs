using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    IList<Keybind> Hotbar0 = new List<Keybind> {

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

    [SerializeField] private Hotbar Hotbar1;
    [SerializeField] private Hotbar Hotbar2;
    [SerializeField] private Hotbar Hotbar3;

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
                    DoHotbarSlot(slot.GetAction(), kb.Name);
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
                    DoHotbarSlot(slot.GetAction(), kb.Name);
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
                    DoHotbarSlot(slot.GetAction(), kb.Name);
                    break;
                }
            }
        }
        //foreach (var kb in Hotbar0)
        //{
        //    if (Input.GetKeyDown(kb.KeyCode))
        //    {
        //        if (kb.Modifier.HasFlag(KeyModifier.None) ||
        //            ( kb.Modifier.HasFlag(KeyModifier.Alt) && (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) ) ||
        //            ( kb.Modifier.HasFlag(KeyModifier.Shift) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) ) ||
        //            ( kb.Modifier.HasFlag(KeyModifier.Control) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) ) )
        //        {
        //            DoHotbarSlot(kb.HotbarSlot.GetAction(), kb.Name);
        //            //GetType().GetMethod("Do" + kb.Name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Invoke(this, new[] { kb.Skill });
        //            break;
        //        }
        //    }
        //}
    }

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
