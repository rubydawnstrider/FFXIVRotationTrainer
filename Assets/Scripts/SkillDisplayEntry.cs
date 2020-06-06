using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDisplayEntry : MonoBehaviour
{
    [SerializeField] private GameObject _skillButton;
    [SerializeField] private Text _skillNameText;
    [SerializeField] private Text _skillTypeText;

    public void Initialize(GameObject skillButtonPrefab, Skill skill)
    {
        _skillButton = Instantiate(skillButtonPrefab);
        _skillButton.name = skill.Name;
        _skillButton.transform.SetParent(transform);
        _skillButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(2, -2);
        if (skill.SkillType == SkillType.Ability)
        {
            _skillButton.AddComponent<AbilitySkill>();
            _skillButton.GetComponent<AbilitySkill>().Initialize(skill);
        }
        else if (skill.SkillType == SkillType.Weaponskill)
        {
            _skillButton.AddComponent<WeaponSkill>();
            _skillButton.GetComponent<WeaponSkill>().Initialize(skill);
        }
        else if (skill.SkillType == SkillType.Spell)
        {
            _skillButton.AddComponent<SpellSkill>();
            _skillButton.GetComponent<SpellSkill>().Initialize(skill);
        }
        //_skillButton.GetComponent<SkillIcon>().Initialize(skill);

        _skillNameText.text = skill.Name;
        _skillTypeText.text = skill.SkillType.ToString();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
