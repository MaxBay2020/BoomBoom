using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public GameObject exlosionPrefab;

    //spike hit the ground
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Tilemap" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Shield")
        {
            GameObject explosion = Instantiate(exlosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 0.3f);
            Destroy(this.gameObject);
        }
    }
}
