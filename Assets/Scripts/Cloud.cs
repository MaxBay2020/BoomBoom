using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cloud : MonoBehaviour
{
    [SerializeField] private float fadeSpeed;
    private Material myMaterial;

    private void Start()
    {
        myMaterial = GetComponent<SpriteRenderer>().material;
    }

    //player stay, fade out
    private void OnCollisionStay2D(Collision2D collision)
    {
        myMaterial.DOColor(Color.clear, fadeSpeed);
        Destroy(this.gameObject, fadeSpeed - 0.5f);
    }
}
