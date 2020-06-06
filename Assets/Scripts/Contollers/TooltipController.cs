using System.Collections.Generic;
using UnityEngine;

public class TooltipController : MonoBehaviour
{
    [SerializeField] private GameObject _tooltipPrefab;

    public static TooltipController Instance { get; private set; }

    private Dictionary<string, GameObject> _tooltips;
    private bool _preventTooltips;

    public TooltipController ()
    {
        _tooltips = new Dictionary<string, GameObject>();
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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
        GameObject tt = null;
        if(!_preventTooltips && _tooltips.TryGetValue(name, out tt))
        {
            tt.SetActive(true);
        }
    }

    public void HideTooltip(string name)
    {
        if (!_preventTooltips && _tooltips.TryGetValue(name, out var tt))
        {
            tt.SetActive(false);
        }
    }

    public void SetPreventTooltips(bool preventTooltips)
    {
        _preventTooltips = preventTooltips;
        if(_preventTooltips)
        {
            foreach(var kv in _tooltips)
            {
                if (kv.Value.activeInHierarchy)
                {
                    kv.Value.SetActive(false);
                }
            }
        }
    }
}
