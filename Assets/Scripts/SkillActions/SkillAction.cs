using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillAction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    protected Image Icon { get; private set; }
    
    public Skill Skill { get; private set; }

    [SerializeField] private string SkillName;


    protected bool _isOnHotbar;
    protected bool _canRecast = true;
    public bool CanRecast { get { return _canRecast; } }


    void Awake()
    {
        Icon = GetComponent<Image>();
    }

    public virtual void Initialize(Skill skill)
    {
        Skill = skill;
        SkillName = skill.Name;
        if (skill != null)
        {
            var sprite = Resources.Load<Sprite>("Icons/Skills/" + Skill.Job + "/" + Skill.IconName);
            Icon.sprite = sprite;
            TooltipController.Instance.CreateTooltip(skill, sprite);
            EventController.StartListening(Skill.Name, StartRecastCountdown);

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipController.Instance.ShowTooltip(Skill.Name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipController.Instance.HideTooltip(Skill.Name);
    }

    public virtual void AddToHotbar()
    {
        _isOnHotbar = true;
    }

    protected virtual void StartRecastCountdown(string skillName) { }
    protected virtual void StartGcdCountdown(string skillName) { }
    protected virtual void EnableRecast() { }
    public virtual void TriggerSkill() { }
    public virtual void SetupListeners() { }

}
