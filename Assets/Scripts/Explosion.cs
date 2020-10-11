using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Explosion : MonoBehaviour
{
    public GameObject explosionPrefab;
    [SerializeField] GameObject[] tileBlocks;

    //[SerializeField] private Camera camera;
    private Cinemachine.CinemachineImpulseSource shakeImpulse;

    private bool playOnce = true;

    private void Start()
    {
        shakeImpulse = GetComponent<Cinemachine.CinemachineImpulseSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Explosion")
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            //play explosion sound
            SoundManger.Instance.PlayRockExplosionSound();

            shakeImpulse.GenerateImpulse();

            Destroy(this.gameObject);

            foreach (var block in tileBlocks)
            {
                block.GetComponent<SpriteRenderer>().DOColor(Color.clear, 3f);

                Destroy(block, 1);
            }
        }
    }
}
