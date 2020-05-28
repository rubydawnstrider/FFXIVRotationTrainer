using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillIcon : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Image _image;
    private Skill _skill;


    // Start is called before the first frame update
    void Start()
    {
        if (_spriteRenderer == null)
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }
        _image = gameObject.GetComponent<Image>();
        UpdateIcon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(Skill skill)
    {
        _skill = skill;
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if (_skill == null)
        {
            return;
        }
        var path = "Icons/Skills/" + _skill.Job + "/" + _skill.IconName;
        var sprite = Resources.Load<Sprite>(path);
        if (_spriteRenderer != null)
        {
            _spriteRenderer.sprite = sprite;
        }
        if (_image != null)
        {
            _image.sprite = sprite;
        }
    }

    public Skill GetSkill() { return _skill; }

}
