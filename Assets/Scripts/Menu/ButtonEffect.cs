using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        transform.DOScale(1.1f, 0.3f).SetAutoKill(false).SetEase(Ease.InOutBack).Pause();
    }

    //mouse over scale up
    public void OnPointerEnter(PointerEventData eventData)
    {
        SoundManager.Instance.OnMouseOver();
        rectTransform.DOPlayForward();
    }

    //mouse down scale down
    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.DOPlayBackwards();
    }

}
