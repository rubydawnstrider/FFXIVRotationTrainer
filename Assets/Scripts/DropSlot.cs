using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; ;
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position; ;
            eventData.pointerDrag.GetComponent<RectTransform>().parent = GetComponent<RectTransform>(); ;
        }
    }
}
