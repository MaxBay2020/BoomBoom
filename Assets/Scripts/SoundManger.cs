using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour
{
    public AudioClip walkClip, jumpClip, chestClip;
    public AudioClip[] explosionClips;
    public AudioClip[] coinClip;
    public GameObject player;
    public GameObject rockExplosionSoundPos;
    public GameObject sawExplosionSoundPos;
    public GameObject spikesPos;
    public Camera mainCamera;


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
        AudioSource.PlayClipAtPoint(jumpClip, mainCamera.transform.position);
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
}
