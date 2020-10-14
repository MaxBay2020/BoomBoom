using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeFall : MonoBehaviour
{
    public List<Transform> fallPos;
    public GameObject[] spikes;

    private bool start = false;

    public float tempTime;
    //public float timeSpan = 4;

    private void Start()
    {
        foreach (Transform eachPos in transform)
        {
            fallPos.Add(eachPos);
        }
    }

    private void FixedUpdate()
    {
        if (start)
        {
            if (tempTime > 3)
            {
                foreach (Transform eachPos in fallPos)
                {
                    Instantiate(spikes[Random.Range(0, spikes.Length - 1)], eachPos.position, Quaternion.identity);
                }
                tempTime = 0;
            }
            else
            {
                tempTime += Time.fixedDeltaTime;
            }
        }
    }

    //player enter and stay at the zone, spikes fall
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            start = true;
        }

    }

    //player leave the zone, spikes top to fall
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            start = false;
        }

    }
}
