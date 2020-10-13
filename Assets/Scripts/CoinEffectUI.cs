using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CoinEffectUI : MonoBehaviour
{
    public Text coinTotalAmountTxt;
    public Transform coinTotalAmount;

    public Text coinGet;
    private int score = 0;

    private void Start()
    {
        coinTotalAmountTxt.text = "/"+coinTotalAmount.childCount;
    }

    //coin touch the coin GUI
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            //score to UI
            Destroy(collision.gameObject);
            score++;
            coinGet.text = score+"";
            coinGet.gameObject.transform.DOScale(1.5f, 0.2f);
            StartCoroutine(Effect());
        }
    }

    //scale up and scale down effect
    IEnumerator Effect()
    {
        yield return new WaitForSeconds(0.2f);
        coinGet.gameObject.transform.DOScale(1f, 0.2f);
    }
}
