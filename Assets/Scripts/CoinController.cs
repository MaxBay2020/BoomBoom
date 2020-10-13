using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    [Range(0.2f,15)][SerializeField] private float _range = 5f;

    [Range(1, 10)] [SerializeField] private float _durationTime = 1;

    public GameObject coinStoreUI;
    private bool isTouchCoin = false;

    private void Start()
    {
        this.transform.DOMoveY(transform.position.y+ _range, _durationTime).SetLoops(-1, LoopType.Yoyo);
    }

    private void FixedUpdate()
    {
        if (isTouchCoin)
        {
            //go to coin GUI
            transform.position = Vector3.MoveTowards(this.gameObject.transform.position, coinStoreUI.transform.position, 150 * Time.deltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isTouchCoin)
        {
            //play sound
            SoundManger.Instance.PlayCoinSound();

            //move to score UI
            isTouchCoin = true;

            //kill the animation;
            transform.DOKill();

        }
    }
}
