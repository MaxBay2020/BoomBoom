using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LeftAndRight : MonoBehaviour
{
    [SerializeField] private float x;
    private float myTime =0;
    [Range(0.1f,6)][SerializeField] private float stopTime;
    [SerializeField] private float animTime;

    void Start()
    {
        transform.DOMoveX(transform.position.x + x, animTime).SetEase(Ease.InOutBack).SetAutoKill(false).Pause();
    }

    void FixedUpdate()
    {
        myTime += Time.fixedDeltaTime;

        if(myTime > (animTime+stopTime) && myTime < 2 * (animTime + stopTime))
        {
            transform.DOPlayForward();

        }
        else if (myTime > 2 * (animTime + stopTime))
        {
            transform.DOPlayBackwards();

            myTime = 0;
        }
    }
}
