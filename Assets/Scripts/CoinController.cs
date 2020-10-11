using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinController : MonoBehaviour
{
    [Range(0.2f,15)][SerializeField] private float _range = 5f;

    [Range(1, 10)] [SerializeField] private float _durationTime = 1;

    private void Start()
    {
        this.transform.DOMoveY(transform.position.y+ _range, _durationTime).SetLoops(-1, LoopType.Yoyo);
    }

}
