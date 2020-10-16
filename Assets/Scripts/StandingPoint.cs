using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingPoint : MonoBehaviour
{
    public GameObject player;
    public GameObject playerLayer;

    //player moves as floating island
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FloatingIsland")
        {
            player.transform.SetParent(collision.gameObject.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FloatingIsland")
        {
            player.transform.SetParent(playerLayer.transform);
        }
    }
}
