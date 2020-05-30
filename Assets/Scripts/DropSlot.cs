using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Text HotKeyTextNoModifier;
    [SerializeField] private Text HotKeyText;
    [SerializeField] private Text HotKeyModifierText;
    [SerializeField] private Button ActionButton;
    


    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag != null)
        {
            var rect = GetComponent<RectTransform>();
            var dragRect = eventData.pointerDrag.GetComponent<RectTransform>();
            var dragParentDropSlot = eventData.pointerDrag.transform.parent.GetComponent<DropSlot>();

            var tmp = eventData.pointerDrag.GetComponent<Button>();

            //todo if dragged skill coming from another hotbarslot, swap them? if hotbarskill is set already
            if (ActionButton == null) // hotbarslot is empty. just move here
            {
                dragRect.anchoredPosition = rect.anchoredPosition;
                dragRect.position = rect.position; ;
                dragRect.parent = rect;

                if (tmp != null)
                {
                    var p = eventData.pointerDrag;
                    var pn = p.name;
                    var p2 = p.transform.parent;
                    var p2n = p2.name;
                    var p3 = p2.GetComponent<DropSlot>();
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
                if (eventData.pointerDrag.transform.parent.GetComponent<DropSlot>() != null)
                {
                    var tmpPos = eventData.pointerDrag.transform.parent.GetComponent<RectTransform>().position;
                    var tmpAnchor = eventData.pointerDrag.transform.parent.GetComponent<RectTransform>().anchoredPosition;
                    var tmpParent = eventData.pointerDrag.transform.parent.GetComponent<RectTransform>();

                    dragRect.anchoredPosition = rect.anchoredPosition;
                    dragRect.position = rect.position; ;
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

    public void SetHotKeyText(string hotkeyText, string modifierText)
    {
        if (string.IsNullOrEmpty(modifierText))
        {
            HotKeyModifierText.text = "";
            HotKeyText.text = "";
            HotKeyTextNoModifier.text = hotkeyText;
        }
        else
        {
            HotKeyModifierText.text = modifierText;
            HotKeyText.text = hotkeyText;
            HotKeyTextNoModifier.text = "";
        }
    }

    public void ClearAction()
    {
        SetAction(null);
    }
    public void SetAction(Button action)
    {
        ActionButton = action;
        Skill skill = null;
        if (action != null)
        {
            skill = action.GetComponent<SkillIcon>().GetSkill();
        }
        InputController.Instance().SetHotbarSlotSkill(name, skill);
    }

}
