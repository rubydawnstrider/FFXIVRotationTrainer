using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*************************************************************************
 * Things to add still:
 *   1. keybinds
 *   2. keys do actions
 *   3. account for cast time
 *   4. account for recast time
 *   5. account for gcd
 *   6. change hotbar shape (3x4 vs 12x1 etc)
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
    [SerializeField] private string SkillsFilename;
    [SerializeField] private IList<Skill> Skills;
    [SerializeField] private GameObject _skillContainer;
    [SerializeField] private GameObject _skillIconPrefab;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Button _buttonPrefab;
    [SerializeField] private Image _hotbarSlotPrefab;

    private static TrainerController _instance;

    public static TrainerController Instance() { return _instance; }

    //[SerializeField] private SkillsList Skills;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        Skills = XmlParser<Skill>.ParseListFromXmlFile(SkillsFilename);
        //Skills = XmlParser<SkillsList>.ParseObjectFromXmlFile(SkillsFilename);
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
