using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour
{
    public AudioClip jumpClip, chestClip, savePointClip, destinationClip;
    public AudioClip[] explosionClips;
    public AudioClip[] coinClip;
    public GameObject player;
    public GameObject rockExplosionSoundPos;
    public GameObject sawExplosionSoundPos;
    public GameObject spikesPos;
    public Camera mainCamera;
    public AudioClip mouseOverClip, clickClip;

    private static SoundManger _instance;

    public static SoundManger Instance
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

    //play jump sound
    public void PlayJumpSound()
    {
        AudioSource.PlayClipAtPoint(jumpClip, mainCamera.transform.position, 0.2f);
    }

    //play rock explosion sound
    public void PlayRockExplosionSound()
    {
        AudioSource.PlayClipAtPoint(explosionClips[Random.Range(0, explosionClips.Length - 1)], mainCamera.transform.position);
    }

    //play saw explosion sound
    public void PlaySawExplosionSound()
    {
        AudioSource.PlayClipAtPoint(explosionClips[Random.Range(0,explosionClips.Length-1)], sawExplosionSoundPos.transform.position);
    }

    //play spikes explosion sound
    public void PlaySpikesExplosionSound()
    {
        AudioSource.PlayClipAtPoint(explosionClips[Random.Range(0, explosionClips.Length - 1)], mainCamera.transform.position);
    }

    //play coin sound
    public void PlayCoinSound()
    {
        AudioSource.PlayClipAtPoint(coinClip[Random.Range(0,coinClip.Length-1)], mainCamera.transform.position);
    }

    //play chest open sound
    public void ChestOpenSound()
    {
        AudioSource.PlayClipAtPoint(chestClip, mainCamera.transform.position,0.5f);
    }

    //play save point sound
    public void SavePointSound()
    {
        AudioSource.PlayClipAtPoint(savePointClip, mainCamera.transform.position, 1);
    }


    /// <summary>
    /// mouse over sound
    /// </summary>
    public void OnMouseOverSound()
    {
        AudioSource.PlayClipAtPoint(mouseOverClip, mainCamera.transform.position,0.5f);
    }

    /// <summary>
    /// click sound
    /// </summary>
    public void OnMouseClickSound()
    {
        AudioSource.PlayClipAtPoint(clickClip, mainCamera.transform.position, 0.5f);
    }

    //destination clip sound
    public void OnDestinationArriveSound()
    {
        AudioSource.PlayClipAtPoint(destinationClip, mainCamera.transform.position, 0.5f);
    }
}
