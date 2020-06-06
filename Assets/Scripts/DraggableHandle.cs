using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableHandle : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Vector2 _originalPoint;
    [SerializeField] private RectTransform _rectTransform;
    
    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition = _originalPoint += eventData.delta / TrainerController.Instance.GetCanvas().scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _originalPoint = _rectTransform.anchoredPosition;
        TooltipController.Instance.SetPreventTooltips(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        TooltipController.Instance.SetPreventTooltips(false);
    }
}
