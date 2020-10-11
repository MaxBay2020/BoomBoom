using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWall : MonoBehaviour
{
    private Cinemachine.CinemachineCollisionImpulseSource MyInpulse;

    private void Start()
    {
        MyInpulse = GetComponent<Cinemachine.CinemachineCollisionImpulseSource>();
    }

    //hit the ground, shake vCamera
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tilemap")
        {
            MyInpulse.GenerateImpulse();
        }
    }

}
