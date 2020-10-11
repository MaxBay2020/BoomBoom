using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [Range(1, 10)] [SerializeField] private float _cameraOffsetX = 5f;
    [Range(1, 10)] [SerializeField] private float _cameraOffsetY = 5f;
    private bool flag=true;

    private void FixedUpdate()
    {

        if (flag && this.transform.position.x <= -0.7f)
        {
            flag = false;
            return;
        }

        //check whether the player exceed the X range
        if (player.position.x<this.transform.position.x-0.5f* _cameraOffsetX)
        {
            this.transform.position = new Vector3(
                player.transform.position.x + 0.5f * _cameraOffsetX,
                this.transform.position.y,
                this.transform.position.z
                );
            flag = true;
        }else if (player.transform.position.x > this.transform.position.x + 0.5f * _cameraOffsetX)
        {
            this.transform.position = new Vector3(
                player.transform.position.x - 0.5f * _cameraOffsetX,
                this.transform.position.y,
                this.transform.position.z
                );
            flag = true;
        }

        //check whether player exceed Y range
        if (player.transform.position.y > this.transform.position.y + 0.5f * _cameraOffsetY)
        {
            this.transform.position = new Vector3(
                this.transform.position.x,
                player.transform.position.y - 0.5f * _cameraOffsetY,
                this.transform.position.z
                );
        }else if (player.transform.position.y < this.transform.position.y - 0.5f * _cameraOffsetY)
        {
            this.transform.position = new Vector3(
                this.transform.position.x,
                player.transform.position.y + 0.5f * _cameraOffsetY,
                this.transform.position.z
                );
        }

    }

    //draw helper box
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, new Vector3(_cameraOffsetX, _cameraOffsetY, 0));
    }
}
