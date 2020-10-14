using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    [SerializeField] private RectTransform creditPanel;
    [SerializeField] private RectTransform creditBg;

    private void Start()
    {
        Time.timeScale = 1;
        creditPanel.DOMoveY(0, 0.5f).SetAutoKill(false).SetEase(Ease.OutBack).Pause();
    }

    //player start game
    public void OnStartGameClick()
    {
        SoundManager.Instance.OnMouseClick();
        SceneManager.LoadScene("main");
        Time.timeScale = 1;
    }

    //player exit game
    public void OnCloseClick()
    {
        SoundManager.Instance.OnMouseClick();
        Application.Quit();
    }

    //player click to check credit panel
    public void OnInfoClick()
    {
        SoundManager.Instance.OnMouseClick();

        creditPanel.DOPlayForward();
        creditBg.GetComponent<Image>().raycastTarget = true;
        creditBg.GetComponent<Image>().DOFade(0.6f, 0.8f);
    }

    //player click to close credit panel
    public void OnCreditPanelCloseClick()
    {
        SoundManager.Instance.OnMouseClick();

        creditPanel.DOPlayBackwards();
        creditBg.GetComponent<Image>().raycastTarget = false;
        creditBg.GetComponent<Image>().DOFade(0, 0.8f);

    }
}
