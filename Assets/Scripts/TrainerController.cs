using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*************************************************************************
 * Things to add still:
 *   0. if slot has a skill already, swap
 *   1. keybinds
 *   2. keys do actions
 *   3. account for cast time
 *   4. account for recast time
 *   5. account for gcd
 *   6. change hotbar shape (3x4 vs 12x1 etc) : separate controls? or save layouts for everything for each setup?
 *   7. customizable keybinds
 *   8. multiple hotbars
 *   9. moveable hotbars
 *  10. battle log
 *  11. other classes :3
 *  12. cd and gcd timer animation
 *  13. STRETCH: charges and job bars
 *  14. STRETCH2: buffs / debuffs
 *  15. STRETCH3: targeting (enemy vs party vs self)
 * 
 ***********************************************************************/


public class TrainerController : MonoBehaviour
{
    [SerializeField] private IList<Skill> Skills;
    [SerializeField] private GameObject _skillContainer;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _skillIconPrefab;
    [SerializeField] private GameObject _skillLogPrefab;
    [SerializeField] private GameObject _skillLogPanel;
    [SerializeField] private ScrollRect _skillLogPanelScroll;
    [SerializeField] private Text _debugText;

    private static TrainerController _instance;

    public static TrainerController Instance() { return _instance; }

    //[SerializeField] private SkillsList Skills;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        try {
            var textAsset = (TextAsset)Resources.Load("Xml/" + /*JOB*/ "GNB");
            var text = textAsset.text;
            Skills = XmlParser<Skill>.ParseXmlFromText(text);
            if (Skills.Count < 1)
            {
                _debugText.text = _debugText.text + System.Environment.NewLine + "no skills";
                Skills.Add(new Skill { Name = "Keen Edge", Job = JobType.GNB, Level = 1, Description = "Delivers an attack with a potency of 200.", RecastTime = 2.5f, CastTime = 0, TargetType = TargetType.Enemy, IconName = "Keen_Edge", SkillType = SkillType.Weaponskill });
            }
            else
            {
                foreach (var skill in Skills)
                {
                    _debugText.text = _debugText.text + System.Environment.NewLine + "skill: " + skill.Name;
                }
            }
        }
        catch (Exception e)
        {
            _debugText.text = "ERROR! " + e.Message + System.Environment.NewLine + e.StackTrace;
        }
    }

    public Canvas GetCanvas()
    {
        return _canvas;
    }

    // Start is called before the first frame update
    void Start()
    {
        var i = -7;
        var j = 3;
        foreach (var s in Skills)
        {
            var skill = Instantiate(_skillIconPrefab);
            skill.name = s.Name;
            skill.transform.SetParent(_canvas.transform, false);
            skill.transform.position = new Vector2(i++, j);
            skill.GetComponent<SkillIcon>().Initialize(s);
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

    public void AddSkillLogEntry(string skillName, Sprite skillIcon)
    {
        var logEntry = Instantiate<GameObject>(_skillLogPrefab, _skillLogPanel.transform);
        logEntry.GetComponent<SkillLogEntry>().Initialize(skillName, skillIcon);
        StartCoroutine(ScrollToBottom());
    }

    private IEnumerator ScrollToBottom()
    {
        yield return new WaitForEndOfFrame();
        _skillLogPanelScroll.verticalNormalizedPosition = 0f;
    }
}
