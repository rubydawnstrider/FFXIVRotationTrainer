using System.Collections;
using UnityEngine;

using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    [SerializeField] private Text SkillName;
    [SerializeField] private Text SkillType;
    [SerializeField] private Text CastTime;
    [SerializeField] private Text RecastTime;
    [SerializeField] private Transform AcquiredContainer;
    [SerializeField] private Text AcquiredLevel;
    [SerializeField] private Text Description;
    [SerializeField] private Image Icon;

    public void Initialize(Skill skill, Sprite icon)
    {
        SkillName.text = skill.Name;
        SkillType.text = skill.SkillType.ToString();
        if (skill.CastTime == 0)
        {
            CastTime.text = "Instant";
        }
        else
        {
            CastTime.text = skill.CastTime.ToString("F2") + "s";
        }
        RecastTime.text = skill.RecastTime.ToString("F2") + "s";
        AcquiredLevel.text = skill.Level.ToString();
        Description.text = skill.Description;
        Icon.sprite = icon;
        //StartCoroutine(ResizeForDesciption());
    }

    private IEnumerator ResizeForDesciption()
    {
        yield return new WaitForEndOfFrame();
        var adjust = LayoutUtility.GetPreferredHeight(Description.rectTransform) - 11 /*default height*/;
        AcquiredContainer.position = new Vector2(AcquiredContainer.position.x, AcquiredContainer.position.y - adjust);
        var rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y + adjust);
    }
}
