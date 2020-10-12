using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cloud : MonoBehaviour
{
    [SerializeField] private float fadeSpeed;
    private Material myMaterial;
    private Color myColor;
    private bool standOnCloud = false;

    private void Start()
    {
        myMaterial = GetComponent<SpriteRenderer>().material;
        myColor = GetComponent<SpriteRenderer>().material.color;
    }

    //player stay, fade out
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            standOnCloud = true;
            
            myMaterial.DOColor(Color.clear, fadeSpeed);
            if (myColor.a<0.01f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    //player exit, fade in
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //standOnCloud = false;
            myMaterial.DOColor(myColor, fadeSpeed);
        }
    }
}
