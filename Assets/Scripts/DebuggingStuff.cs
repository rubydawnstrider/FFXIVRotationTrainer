using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuggingStuff : MonoBehaviour
{
    [SerializeField] private Hotbar _hotbar1;


    public void ReconfigBar(int columns)
    {
        if (_hotbar1.IsInitialized())
        {
            _hotbar1.SetRowsAndColumns(columns, 12 / columns);
        }
        else
        {
            _hotbar1.Initalize(columns, 12 / columns, 40, new List<GameObject>());
        }
    }
}
