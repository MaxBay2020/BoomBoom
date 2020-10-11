using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [Range(2, 20)] [SerializeField] private float xSpeed;
    public GameObject explosionPrefab;
    private bool isShoot;

    void FixedUpdate()
    {
        if (isShoot)
        {
            transform.Translate(Vector3.right * xSpeed * Time.deltaTime, Space.World);

            if (transform.position.x > 10)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 1);
            Destroy(this.gameObject);
        }
    }

    public void WaitForShoot(bool fire)
    {
        isShoot = fire;
    }
}
