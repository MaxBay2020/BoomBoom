using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UpAndDown : MonoBehaviour
{
    [SerializeField] private float y;
    private float myTime = 0;
    [Range(0.1f, 6)] [SerializeField] private float stopTime;
    [SerializeField] private float animTime;

    void Start()
    {
        transform.DOMoveY(transform.position.y+y, animTime).SetEase(Ease.InOutBack).SetAutoKill(false).Pause();

    }

    private void FixedUpdate()
    {
        myTime = Time.fixedDeltaTime + myTime;

        if (myTime > (animTime + stopTime) && myTime<2* (animTime + stopTime))
        {
            //Debug.Log("go up");
            transform.DOPlayForward();
        }
        else if (myTime > 2 * (animTime + stopTime))
        {
            //Debug.Log("go down");
            transform.DOPlayBackwards();
            myTime = 0;

        }
    }

}
