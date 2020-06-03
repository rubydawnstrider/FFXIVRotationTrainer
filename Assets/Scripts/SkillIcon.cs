using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _image;
    private Skill _skill;

    public void Initialize(Skill skill)
    {
        _skill = skill;
        if (_skill == null)
        {
            return;
        }

        var path = "Icons/Skills/" + _skill.Job + "/" + _skill.IconName;
        var sprite = Resources.Load<Sprite>(path);

        _image.sprite = sprite;
        TooltipController.Instance().CreateTooltip(skill, sprite);
    }

    public Skill GetSkill() { return _skill; }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipController.Instance().ShowTooltip(_skill.Name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipController.Instance().HideTooltip(_skill.Name);
    }
}
