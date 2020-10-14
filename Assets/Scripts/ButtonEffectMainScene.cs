using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonEffectMainScene : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //mouse over event
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.1f, 0.3f);
        transform.GetComponent<Image>().DOFade(1, 0.3f);
        //play sound
        SoundManger.Instance.OnMouseOverSound();
    }

    //mouse leave event
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1f, 0.3f);
        transform.GetComponent<Image>().DOFade(0.7f, 0.3f);
    }
}
