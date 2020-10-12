using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeShootTrigger : MonoBehaviour
{
    private bool sendOnce = true;

    //player enter the zone, shoot
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && sendOnce)
        {
            BroadcastMessage("WaitForShoot", true);
            sendOnce = false;
        }
    }

}
