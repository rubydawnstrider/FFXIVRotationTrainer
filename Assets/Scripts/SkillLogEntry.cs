using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillLogEntry : MonoBehaviour
{
    [SerializeField] private Text SkillLogText;
    [SerializeField] private Image SkillLogImage;
    [SerializeField] private Hotbar Hotbar1;
    [SerializeField] private Hotbar Hotbar2;
    [SerializeField] private Hotbar Hotbar3;

    public void Initialize(string text, Sprite image)
    {
        SkillLogText.text = text;
        SkillLogImage.sprite = image;
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
