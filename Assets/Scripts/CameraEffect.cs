using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraEffect : MonoBehaviour
{
    public void Shake()
    {
        transform.DOShakePosition(1,1,20,15,false);
    }

}
