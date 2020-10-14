using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChestOpen : MonoBehaviour
{
    private Animator anim;
    private bool isOpen;
    public Text numberOfChest;
    private int score = 0;
    public GameObject chestTotalAmount;
    public Text chestTotalAmountTxt;

    private void Start()
    {
        anim = GetComponent<Animator>();
        chestTotalAmountTxt.text = "/" + chestTotalAmount.transform.childCount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("playerTouch", true);
            if (!isOpen)
            {
                //play sound
                //SoundManger.Instance.PlayCoinSound();
                SoundManger.Instance.ChestOpenSound();

                //score to UI
                score++;
                numberOfChest.gameObject.transform.DOScale(1.5f, 0.2f);
                StartCoroutine(Effect());

                numberOfChest.text = score + "";
            }
            isOpen = true;            
        }
    }

    //scale up and scale down effect
    IEnumerator Effect()
    {
        yield return new WaitForSeconds(0.2f);
        numberOfChest.gameObject.transform.DOScale(1f, 0.2f);
    }
}
