using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class EventManagerMainScene : MonoBehaviour
{
    public RectTransform greyBG;
    public RectTransform[] buttons;

    //menu button click event
    public void MenuOnClick()
    {
        greyBG.GetComponent<Image>().DOFade(0.5f, 0.5f);
        greyBG.GetComponent<Image>().raycastTarget = true;

        //play sound
        SoundManger.Instance.OnMouseClick();

        //show buttons
        foreach (RectTransform button in buttons)
        {
            button.DOLocalMoveY(70, 0.5f).SetEase(Ease.OutBack);
        }

        //pause the game
        StartCoroutine(PauseGame());

    }

    //continue button click event
    public void ContinueOnClick()
    {
        greyBG.GetComponent<Image>().DOFade(0f, 0.5f);
        greyBG.GetComponent<Image>().raycastTarget = false;

        //hide buttons
        foreach (RectTransform button in buttons)
        {
            button.DOLocalMoveY(700, 0.5f).SetEase(Ease.InBack);
        }

        //continue the game
        Time.timeScale = 1;

        //play sound
        SoundManger.Instance.OnMouseClick();
    }

    //retry button click event
    public void RetryOnClick()
    {
        //play sound
        SoundManger.Instance.OnMouseClick();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name+"");

        //continue the game
        Time.timeScale = 1;
    }

    //go back to menu scene
    public void GoToMenuOnClick()
    {
        //play sound
        SoundManger.Instance.OnMouseClick();

        SceneManager.LoadScene("Menu");
    }

    IEnumerator PauseGame()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
    }
}
