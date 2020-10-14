using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SavePoint : MonoBehaviour
{
    public Sprite redFlower;
    private SpriteRenderer sr;
    public Text savingText;
    public Image savingImage;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        savingText.gameObject.SetActive(false);
        savingImage.gameObject.SetActive(false);

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

            //show saving info
            savingText.gameObject.SetActive(true);
            savingImage.gameObject.SetActive(true);

            //hide saving info after certain seconds
            StartCoroutine(HideSavingInfo());

            //add save point to savePoints list
            SavePointsManager.Instance.savePoints.Add(transform);
        }
    }

    IEnumerator HideSavingInfo()
    {
        yield return new WaitForSeconds(2);
        savingText.gameObject.SetActive(false);
        savingImage.gameObject.SetActive(false);
    }
}
