using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SavePoint : MonoBehaviour
{
    public Sprite redFlower;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    //player pass, save game
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //effect
            transform.DOPunchScale(Vector3.one*0.3f,0.3f,6,1);
            sr.sprite = redFlower;
            this.GetComponent<BoxCollider2D>().enabled = false;

            //play save point sound
            SoundManger.Instance.SavePointSound();

            //add save point to savePoints list
            SavePointsManager.Instance.savePoints.Add(transform);
        }
    }
}
