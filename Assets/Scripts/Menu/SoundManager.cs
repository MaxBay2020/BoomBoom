using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public AudioClip mouseOverClip, clickClip;

    /// <summary>
    /// mouse over sound
    /// </summary>
    public void OnMouseOver()
    {
        AudioSource.PlayClipAtPoint(mouseOverClip, new Vector3(0,0,-10));
    }

    /// <summary>
    /// click sound
    /// </summary>
    public void OnMouseClick()
    {
        AudioSource.PlayClipAtPoint(clickClip, new Vector3(0, 0, -10));
    }

}
