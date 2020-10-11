using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public GameObject saw;
    [Range(1, 15)] [SerializeField] private float xSpeed = 2;
    public bool go = false;
    public float xRange = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        //trigger the saw
        if (go)
        {
            saw.transform.Translate(Vector3.left * xSpeed * Time.fixedDeltaTime, Space.World);

        }

        //destory saw and trigger point
        if (saw.transform.position.x < xRange)
        {
            Destroy(this.gameObject);
            go = false;
            Destroy(saw.gameObject);
        }
    }

}
