using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Destination : MonoBehaviour
{
    public RectTransform greyBG;
    public RectTransform[] buttons;
    public Camera mainCamera;
    public Text thankText;

    //player reach destination
    private void OnTriggerEnter2D(Collider2D collision)
    {
        greyBG.GetComponent<Image>().DOFade(0.5f, 0.5f);
        greyBG.GetComponent<Image>().raycastTarget = true;

        this.GetComponent<BoxCollider2D>().enabled = false;

        //play sound
        SoundManger.Instance.OnDestinationArriveSound();
        mainCamera.GetComponent<AudioSource>().enabled = false;

        //show thank text
        thankText.DOFade(1, 0.7f);

        //pause the game
        StartCoroutine(PauseGame());

        //show buttons
        foreach (RectTransform button in buttons)
        {
            button.DOLocalMoveY(-100, 0.5f).SetEase(Ease.OutBack);
        }

    }

    IEnumerator PauseGame()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
    }


}
