using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrigger : Saw
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            go = true;
        }
    }
}
