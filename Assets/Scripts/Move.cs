using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move : MonoBehaviour
{
    //1:move right; -1:move left
    private float _direction;

    //the more, the slower
    private float _speed;

    void Start()
    {
        //randomly choose direction and speed
        _direction = Random.Range(-1, 2)==0?1: Random.Range(-1, 2);
        _speed = Random.Range(15, 40);

    }

    void Update()
    {
        //move
        this.transform.DOMoveX(this.transform.position.x + _direction, _speed);

    }
}
