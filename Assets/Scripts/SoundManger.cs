using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour
{
    public AudioClip walkClip, jumpClip, chestClip, explosionClip;
    public AudioClip[] coinClip;
    public GameObject player;
    public GameObject rockExplosionSoundPos;
    public GameObject sawExplosionSoundPos;
    public GameObject spikesPos;


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
        AudioSource.PlayClipAtPoint(jumpClip, player.transform.position);
    }

    //play rock explosion sound
    public void PlayRockExplosionSound()
    {
        AudioSource.PlayClipAtPoint(explosionClip, rockExplosionSoundPos.transform.position);
    }

    //play saw explosion sound
    public void PlaySawExplosionSound()
    {
        AudioSource.PlayClipAtPoint(explosionClip, sawExplosionSoundPos.transform.position);
    }

    //play spikes explosion sound
    public void PlaySpikesExplosionSound()
    {
        AudioSource.PlayClipAtPoint(explosionClip, spikesPos.transform.position);
    }
}
