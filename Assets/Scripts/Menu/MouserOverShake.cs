using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class MouserOverShake : MonoBehaviour,IPointerEnterHandler
{
    private RectTransform rectTransform;
    public float duration;
    public float zStrength;
    public int viberation;
    public float angle;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.DOShakeRotation(duration, new Vector3(0,0,zStrength),viberation,angle);

    }
}
