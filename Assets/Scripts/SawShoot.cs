using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawShoot : Saw
{
    public GameObject explosionPrefab;
    private Vector3 position;
    private Quaternion rotation;
    public float waiting;
    public AudioClip explosionClip;
    private AudioSource audioSource;

    private void Start()
    {
        position = this.transform.position;
        rotation = this.transform.rotation;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Explosion" || collision.gameObject.tag == "Player")
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(explosionClip, 10);
            }

            GameObject explosion = Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<Collider2D>().enabled = false;
            Destroy(explosion, 2);
            StartCoroutine(Wait(waiting));
        }
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        this.transform.position = position;
        this.transform.rotation = rotation;
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<Collider2D>().enabled = true;

    }
}
