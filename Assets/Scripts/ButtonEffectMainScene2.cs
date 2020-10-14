using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonEffectMainScene2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    //mouse over event
    public void OnPointerEnter(PointerEventData eventData)
    {
        //play animation
        anim.SetBool("MouseOver", true);

        //play sound
        SoundManger.Instance.OnMouseOverSound();
    }

    //mouse leave event
    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetBool("MouseOver", false);
        
    }
}
