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
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _skillIconPrefab;
    [SerializeField] private GameObject _skillDisplayEntryPrefab;
    [SerializeField] private GameObject _skillLogPrefab;
    [SerializeField] private GameObject _skillLogPanel;
    [SerializeField] private GameObject _skillDisplayPanel;

    [SerializeField] private ScrollRect _skillLogPanelScroll;
    [SerializeField] private Text _debugText;

    [SerializeField] private Image _timerOuterImage;
    [SerializeField] private Image _timerInnerImage;
    [SerializeField] private Image _timerGcdWithRecastImage;
    [SerializeField] private Text _recastText;
    public Image TimerOuterImage {  get { return _timerOuterImage; } }
    public Image TimerInnerImage {  get { return _timerInnerImage; } }
    public Image TimerGcdWithRecastImage {  get { return _timerGcdWithRecastImage; } }
    public Text RecastText {  get { return _recastText; } }

    public static TrainerController Instance { get; private set; }

    public static float GcdTime = 2.5f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        Skills = XmlParser<Skill>.ParseXmlFromText(((TextAsset)Resources.Load("Xml/" + /*JOB*/ "GNB")).text);
        foreach (var skill in Skills)
        {
            _debugText.text = _debugText.text + System.Environment.NewLine + "skill: " + skill.Name;
        }
    }

    public Canvas GetCanvas()
    {
        return _canvas;
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (var s in Skills)
        {
            var skillDisplay = Instantiate(_skillDisplayEntryPrefab);
            skillDisplay.GetComponent<SkillDisplayEntry>().Initialize(_skillIconPrefab, s);
            skillDisplay.transform.SetParent(_skillDisplayPanel.transform);
        }
    }

    public void AddSkillLogEntry(string skillName, Sprite skillIcon)
    {
        var logEntry = Instantiate(_skillLogPrefab, _skillLogPanel.transform);
        logEntry.GetComponent<SkillLogEntry>().Initialize(skillName, skillIcon);
        logEntry.transform.SetAsFirstSibling();
        StartCoroutine(ScrollToTop());
        //StartCoroutine(ScrollToBottom());
    }

    private IEnumerator ScrollToBottom()
    {
        yield return new WaitForEndOfFrame();
        _skillLogPanelScroll.verticalNormalizedPosition = 0f;
    }
    private IEnumerator ScrollToTop()
    {
        yield return new WaitForEndOfFrame();
        _skillLogPanelScroll.verticalNormalizedPosition = 1f;
    }
}
