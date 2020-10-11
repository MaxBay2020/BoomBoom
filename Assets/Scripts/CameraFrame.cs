using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFrame : MonoBehaviour
{
    //activating current camera 
    [SerializeField] private GameObject vCamera;

    //list of all vcameras
    private GameObject[] vCameras;

    private void Start()
    {
        vCameras = GameObject.FindGameObjectsWithTag("VCamera");

    }
    //when player enter, switch camera
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        //deactiviate all vCameras;
    //        foreach (GameObject vCamera in vCameras)
    //        {
    //            vCamera.SetActive(false);
    //        }

    //        //activate assigned vCamera true
    //        vCamera.SetActive(true);
    //    }
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //deactiviate all vCameras;
            foreach (GameObject vCamera in vCameras)
            {
                vCamera.SetActive(false);
            }

            //activate assigned vCamera true
            vCamera.SetActive(true);
        }
    }
}
