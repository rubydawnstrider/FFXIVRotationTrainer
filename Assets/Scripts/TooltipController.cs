using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipController : MonoBehaviour
{
    [SerializeField] private GameObject _tooltipPrefab;
    
    private static TooltipController _instance;
    public static TooltipController Instance() { return _instance; }

    private Dictionary<string, GameObject> _tooltips = new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void CreateTooltip(Skill skill, Sprite icon)
    {
        var tt = Instantiate(_tooltipPrefab, transform);
        tt.SetActive(false);
        tt.GetComponent<Tooltip>().Initialize(skill, icon);
        _tooltips.Add(skill.Name, tt);
    }
    public void ShowTooltip(string name)
    {
        if(_tooltips.TryGetValue(name, out var tt))
        {
            tt.SetActive(true);
        }
    }

    public void HideTooltip(string name)
    {
        if (_tooltips.TryGetValue(name, out var tt))
        {
            tt.SetActive(false);
        }
    }
}
