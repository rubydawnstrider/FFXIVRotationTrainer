using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector2 _originalPoint;
    private Vector2 _originalAnchor;
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private bool _returnToStartOnDrop = true;

    public void SetReturnToStartOnDrop(bool returnToStartOnDrop)
    {
        _returnToStartOnDrop = returnToStartOnDrop;
    }
    public bool GetReturnToStartOnDrop()
    {
        return _returnToStartOnDrop;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / TrainerController.Instance().GetCanvas().scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _originalPoint = _rectTransform.position;
        _originalAnchor = _rectTransform.anchoredPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_returnToStartOnDrop)
        {
            _rectTransform.anchoredPosition = _originalAnchor;
            _rectTransform.position = _originalPoint;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.alpha = 1;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0.9f;
    }
}
