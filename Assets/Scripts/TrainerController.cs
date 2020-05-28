using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainerController : MonoBehaviour
{
    [SerializeField] private string SkillsFilename;
    [SerializeField] private IList<Skill> Skills;
    [SerializeField] private GameObject _skillContainer;
    [SerializeField] private GameObject _skillIconPrefab;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Button _buttonPrefab;

    //[SerializeField] private SkillsList Skills;

    private void Awake()
    {
        Skills = XmlParser<Skill>.ParseListFromXmlFile(SkillsFilename);
        //Skills = XmlParser<SkillsList>.ParseObjectFromXmlFile(SkillsFilename);
    }

    // Start is called before the first frame update
    void Start()
    {
        var i = -7;
        var j = 3;
        foreach (var s in Skills)
        {
            var skill = GameObject.Instantiate(_buttonPrefab);
            skill.transform.SetParent(_canvas.transform, false);
            skill.transform.position = new Vector2(i++, j);
            //var skill = GameObject.Instantiate(_skillIconPrefab);
            //skill.transform.parent = _skillContainer.transform;
            //skill.transform.localPosition = new Vector2(i++, j);
            skill.GetComponent<SkillIcon>().Initialize(s);
            //skill.transform.parent = _skillContainer.transform;
            if (i > 6)
            {
                i = -7;
                j--;
            }
        }

        i = 0;
        foreach(Transform t in _skillContainer.transform)
        {
            Debug.Log("Child" + i++ + " icon: " + t.gameObject.GetComponent<SkillIcon>().GetSkill().Name + " (" + t.position.x + "," + t.position.y + ")");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
