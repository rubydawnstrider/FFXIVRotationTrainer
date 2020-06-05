using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HotbarSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Text HotKeyTextNoModifier;
    [SerializeField] private Text HotKeyText;
    [SerializeField] private Text HotKeyModifierText;
    [SerializeField] private Text HotKeyShiftModifierText;
    [SerializeField] private Button ActionButton;
    private bool _hasAction;
    private Keybind _keybind;

    void Awake()
    {
        SetupKeybind();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            var rect = GetComponent<RectTransform>();
            var dragRect = eventData.pointerDrag.GetComponent<RectTransform>();
            var dragParentDropSlot = eventData.pointerDrag.transform.parent.GetComponent<HotbarSlot>();

            var tmp = eventData.pointerDrag.GetComponent<Button>();

            var anchorOffsetV2 = new Vector2(-20, 20);
            var anchorOffsetV3 = new Vector3(-20, 20, 0);

            //todo if dragged skill coming from another hotbarslot, swap them? if hotbarskill is set already
            if (ActionButton == null) // hotbarslot is empty. just move here
            {
                dragRect.anchoredPosition = rect.anchoredPosition + anchorOffsetV2;
                dragRect.position = rect.position + anchorOffsetV3; 
                dragRect.parent = rect;

                if (tmp != null)
                {
                    if (dragParentDropSlot != null)
                    {
                        dragParentDropSlot.ClearAction();
                    }
                    SetAction(tmp);
                    tmp.transform.SetAsFirstSibling();
                }
            }
            else // hotbar slot set, swap positions of skills
            {
                if (eventData.pointerDrag.transform.parent.GetComponent<HotbarSlot>() != null)
                {
                    var tmpPos = eventData.pointerDrag.transform.parent.GetComponent<RectTransform>().position + anchorOffsetV3;
                    var tmpAnchor = eventData.pointerDrag.transform.parent.GetComponent<RectTransform>().anchoredPosition + anchorOffsetV2;
                    var tmpParent = eventData.pointerDrag.transform.parent.GetComponent<RectTransform>();

                    dragRect.anchoredPosition = rect.anchoredPosition + anchorOffsetV2;
                    dragRect.position = rect.position +anchorOffsetV3;
                    dragRect.parent = rect;

                    ActionButton.GetComponent<RectTransform>().anchoredPosition = tmpAnchor;
                    ActionButton.GetComponent<RectTransform>().position = tmpPos;
                    ActionButton.GetComponent<RectTransform>().parent = tmpParent;

                    dragParentDropSlot.SetAction(ActionButton);
                    ActionButton.transform.SetAsFirstSibling();
                    SetAction(tmp);
                    tmp.transform.SetAsFirstSibling();
                }
                else
                {
                    // moving unslotted into slotted. just destroy the prev slot?
                    Destroy(ActionButton.gameObject);
                    ClearAction();

                    dragRect.anchoredPosition = rect.anchoredPosition;
                    dragRect.position = rect.position; ;
                    dragRect.parent = rect;
                    SetAction(tmp);
                    tmp.transform.SetAsFirstSibling();

                }
            }

        }
    }

    public void SetHotKeyText(KeyCode hotkey, KeyModifier modifier)
    {
        _keybind.KeyCode = hotkey;
        _keybind.Modifier = modifier;
        // todo add in some handling for special cases like space, numpad, and keyboard-number values;
        if (modifier.HasFlag(KeyModifier.None))
        {
            HotKeyModifierText.text = "";
            HotKeyShiftModifierText.enabled = false;
            HotKeyText.text = "";
            HotKeyTextNoModifier.text = hotkey.ToString();
        }
        else
        {
            if (modifier.HasFlag(KeyModifier.Shift))
            {
                HotKeyShiftModifierText.enabled = false;
                HotKeyModifierText.text = "";
            }
            else
            {
                HotKeyShiftModifierText.enabled = false;
                if (modifier.HasFlag(KeyModifier.Alt))
                {
                    HotKeyModifierText.text = "A";
                }
                else
                {
                    HotKeyModifierText.text = "C";
                }
            }
            HotKeyText.text = hotkey.ToString();
            HotKeyTextNoModifier.text = "";
        }
    }

    public void ClearAction()
    {
        SetAction(null);
    }
    public void SetAction(Button action)
    {
        _hasAction = action != null;
        ActionButton = action;
    }
    public Skill GetAction()
    {
        return ActionButton.GetComponent<SkillIcon>().GetSkill();
    }
    public Keybind GetKeybind()
    {
        if (_keybind == null)
        {
            SetupKeybind();
        }
        return _keybind;
    }
    private void SetupKeybind()
    {
        _keybind = new Keybind { Name = transform.parent.name + name, HotbarSlot = this };
        // try to get the bind from the text
        var key = HotKeyText.text;
        if (string.IsNullOrEmpty(key))
        {
            key = HotKeyTextNoModifier.text;
        }
        if (!string.IsNullOrEmpty(key))
        {        // handle special cases
            if (key.StartsWith("Num")) // num pad
            {
                if (key == "Num-") { _keybind.KeyCode = KeyCode.KeypadMinus; }
                else if (key == "Num+") { _keybind.KeyCode = KeyCode.KeypadPlus; }
                else if (key == "Num/") { _keybind.KeyCode = KeyCode.KeypadDivide; }
                else if (key == "Num*") { _keybind.KeyCode = KeyCode.KeypadMultiply; }
                else if (key == "Num.") { _keybind.KeyCode = KeyCode.KeypadPeriod; }
                else { _keybind.KeyCode = (KeyCode)Enum.Parse(typeof(KeyCode), "Keypad" + key.Substring(3)); }
            }
            else if (key == "1") { _keybind.KeyCode = KeyCode.Alpha1; }
            else if (key == "2") { _keybind.KeyCode = KeyCode.Alpha2; }
            else if (key == "3") { _keybind.KeyCode = KeyCode.Alpha3; }
            else if (key == "4") { _keybind.KeyCode = KeyCode.Alpha4; }
            else if (key == "5") { _keybind.KeyCode = KeyCode.Alpha5; }
            else if (key == "6") { _keybind.KeyCode = KeyCode.Alpha6; }
            else if (key == "7") { _keybind.KeyCode = KeyCode.Alpha7; }
            else if (key == "8") { _keybind.KeyCode = KeyCode.Alpha8; }
            else if (key == "9") { _keybind.KeyCode = KeyCode.Alpha9; }
            else if (key == "0") { _keybind.KeyCode = KeyCode.Alpha0; }
            else if (key == "-") { _keybind.KeyCode = KeyCode.Minus; }
            else if (key == "=") { _keybind.KeyCode = KeyCode.Equals; }
            else if (Enum.TryParse<KeyCode>(key, out var keyCode))
            {
                _keybind.KeyCode = keyCode;
            }

            var modifier = HotKeyModifierText.text;
            if (string.IsNullOrEmpty(HotKeyModifierText.text) && HotKeyShiftModifierText.IsActive())
            {
                modifier = "S";
            }
            switch (modifier)
            {
                case "C":
                    _keybind.Modifier = KeyModifier.Control;
                    break;
                case "A":
                    _keybind.Modifier = KeyModifier.Alt;
                    break;
                case "S":
                    _keybind.Modifier = KeyModifier.Shift;
                    break;
                default:
                    _keybind.Modifier = KeyModifier.None;
                    break;
            }
        }
    }
    public Sprite GetCurrentImage()
    {
        return ActionButton.GetComponent<Image>().sprite;
    }
    public bool HasAction() { return _hasAction; }

}
