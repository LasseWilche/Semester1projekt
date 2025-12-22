using UnityEngine;
using UnityEngine.EventSystems;

public class HoverEnlarger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float SizeDifference = 1.1f;
    private Vector2 OGSize;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        OGSize = rectTransform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.localScale = OGSize * SizeDifference;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.localScale = OGSize;
    }
}
