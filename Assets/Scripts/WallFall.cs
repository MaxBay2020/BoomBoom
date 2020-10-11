using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFall : MonoBehaviour
{
    [SerializeField] private GameObject leftWall;

    //player enter, wall falls
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            leftWall.GetComponent<Rigidbody2D>().gravityScale = 6;
        }
    }
}
