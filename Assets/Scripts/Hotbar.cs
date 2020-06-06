using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    [SerializeField] private GameObject Slot1 = null;
    [SerializeField] private GameObject Slot2 = null;
    [SerializeField] private GameObject Slot3 = null;
    [SerializeField] private GameObject Slot4 = null;
    [SerializeField] private GameObject Slot5 = null;
    [SerializeField] private GameObject Slot6 = null;
    [SerializeField] private GameObject Slot7 = null;
    [SerializeField] private GameObject Slot8 = null;
    [SerializeField] private GameObject Slot9 = null;
    [SerializeField] private GameObject Slot10 = null;
    [SerializeField] private GameObject Slot11 = null;
    [SerializeField] private GameObject Slot12 = null;
    [SerializeField] private Text HotbarLabel;

    private const string HOTBARSLOT_TAG = "HotBarSlot";

    private float _slotSize = 40;
    private float _hotbarLabelHorizontalOffset = -46;
    private int _rows = 1;
    private int _columns = 12;
    private float _width;
    private float _height;
    private bool _isInitialized;

    public bool IsInitialized()
    {
        return _isInitialized;
    }

    public void Initialize(int columns, int rows, float slotSize, IList<GameObject> slots)
    {
        if (_isInitialized)
        {
            Debug.LogWarning("Already initalized, use SetColumnsAndRows to change the layout");
            return;
        }

        if (slots.Count != 12)
        {
            // attempt to find children by the "HotbarSlot" tag
            slots = gameObject.FindChildrenWithTag(HOTBARSLOT_TAG);
            if (slots.Count != 12)
            {
                Debug.LogError("Not all slots are passed in and there were not 12 slots found on the hotbar. Aborting Initialize and throwing ArugmentException");
                throw new ArgumentException("Must pass in 12 slot objects", "slots");
            }
        }

        _slotSize = slotSize;

        Slot1  = slots[0];
        Slot2  = slots[1];
        Slot3  = slots[2];
        Slot4  = slots[3];
        Slot5  = slots[4];
        Slot6  = slots[5];
        Slot7  = slots[6];
        Slot8  = slots[7];
        Slot9  = slots[8];
        Slot10 = slots[9];
        Slot11 = slots[10];
        Slot12 = slots[11];

        SetRowsAndColumns(columns, rows);

        _isInitialized = true;
    }
    
    // Start is called before the first frame update
    void Awake()
    {
        Initialize(12, 1, 40, new List<GameObject>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRowsAndColumns(int columns, int rows)
    {
        if (columns == _columns && _rows == rows)
        {
            Debug.Log("Nothing to change.");
            return;
        }

        if (rows * columns != 12)
        {
            Debug.LogWarning("invalid row and column configuration for hotbar " + gameObject.name + ". rows and columns must make a product equal to 12. rows(" + rows + ") * columns(" + columns + ") = " + (rows * columns) + ". Defaulting to 1 row and 12 columns...");
            rows = 1;
            columns = 12;
        }

        _columns = columns;
        _rows = rows;

        _width = (_slotSize * _columns) + 14 + (3 * (_columns - 1));
        _height = (_slotSize * _rows) + 14 + (3 * (_rows- 1));
        GetComponent<RectTransform>().sizeDelta = new Vector2(_width, _height);

        var index = 0; //easier than calculating the index from c and r below

        for (var r = _rows-1; r > -1; r--)
        {
            var rSpacing = 3;
            if (r < 1)
            {
                rSpacing = 0;
            }
            var y = (_height / -2) + 7 + (r * (_slotSize + rSpacing)) + (_slotSize / 2);

            for (var c = 0; c < _columns; c++)
            {
                var cSpacing = 3;
                if (c < 1)
                {
                    cSpacing = 0;
                }
                var x = (_width / -2) + 7 + (c * (_slotSize + cSpacing)) + (_slotSize / 2);

                var pos = new Vector2(x, y);

                index++;
                switch (index)
                {
                    case 1:
                        Slot1.GetComponent<RectTransform>().anchoredPosition = pos;
                        HotbarLabel.rectTransform.anchoredPosition = new Vector2(x + _hotbarLabelHorizontalOffset, y);
                        break;
                    case 2:
                        Slot2.GetComponent<RectTransform>().anchoredPosition = pos;
                        break;
                    case 3:
                        Slot3.GetComponent<RectTransform>().anchoredPosition = pos;
                        break;
                    case 4:
                        Slot4.GetComponent<RectTransform>().anchoredPosition = pos;
                        break;
                    case 5:
                        Slot5.GetComponent<RectTransform>().anchoredPosition = pos;
                        break;
                    case 6:
                        Slot6.GetComponent<RectTransform>().anchoredPosition = pos;
                        break;
                    case 7:
                        Slot7.GetComponent<RectTransform>().anchoredPosition = pos;
                        break;
                    case 8:
                        Slot8.GetComponent<RectTransform>().anchoredPosition = pos;
                        break;
                    case 9:
                        Slot9.GetComponent<RectTransform>().anchoredPosition = pos;
                        break;
                    case 10:
                        Slot10.GetComponent<RectTransform>().anchoredPosition = pos;
                        break;
                    case 11:
                        Slot11.GetComponent<RectTransform>().anchoredPosition = pos;
                        break;
                    case 12:
                        Slot12.GetComponent<RectTransform>().anchoredPosition = pos;
                        break;
                }
            }
        }
    }

    public IList<HotbarSlot> GetHotbarSlots()
    {
        return new List<HotbarSlot>
        {
            Slot1.GetComponent<HotbarSlot>(),
            Slot2.GetComponent<HotbarSlot>(),
            Slot3.GetComponent<HotbarSlot>(),
            Slot4.GetComponent<HotbarSlot>(),
            Slot5.GetComponent<HotbarSlot>(),
            Slot6.GetComponent<HotbarSlot>(),
            Slot7.GetComponent<HotbarSlot>(),
            Slot8.GetComponent<HotbarSlot>(),
            Slot9.GetComponent<HotbarSlot>(),
            Slot10.GetComponent<HotbarSlot>(),
            Slot11.GetComponent<HotbarSlot>(),
            Slot12.GetComponent<HotbarSlot>()
        };
    }

    public void ChangeColumns(int columns)
    {
        var rows = 12 / columns;
        SetRowsAndColumns(columns, rows);
    }
}
