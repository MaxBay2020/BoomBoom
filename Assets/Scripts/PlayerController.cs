﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(1, 20)] [SerializeField] private float _speed = 5;

    private Rigidbody2D rBody;

    [SerializeField] private float _jump_force = 20;

    [SerializeField] private Transform _circle_pos;

    private float _radius = 0.1f;

    [SerializeField] private LayerMask _whatIsGround;

    private bool isGrounded = false;

    private Animator anim;

    private bool isFacingRight = true;

    public GameObject shield;

    private Vector3 shieldRotation = new Vector3(-76, 0, 2.2f);
    [Range(0.1f, 2)] [SerializeField] private float distanceOverHead = 0.5f;

    private bool hasShield = false;

    public AudioClip dieClip;
    private AudioSource audioSource;

    void Start()
    {
        rBody = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");

        //move code
        rBody.velocity = new Vector2(horiz * _speed, rBody.velocity.y);

        if (horiz != 0 && !audioSource.isPlaying)
        {
            //play walk sound
            audioSource.Play();
        }

        //jump code
        isGrounded = GroundedCheck();
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            rBody.AddForce(new Vector2(0, _jump_force));
            isGrounded = false;

            //play jump sound, stop walk sound
            audioSource.Pause();
            SoundManger.Instance.PlayJumpSound();
        }

        //run in different direction
        if ((isFacingRight && rBody.velocity.x < 0) || (!isFacingRight && rBody.velocity.x > 0))
        {
            Flip();
        }

        #region animation
        //animation changes
        //change idle to run animation
        anim.SetFloat("xVelocity", Mathf.Abs(rBody.velocity.x));

        //change idle to jump animation
        anim.SetFloat("yVelocity", rBody.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetInteger("percent", Random.Range(0, 101));
        #endregion
    }

    /// <summary>
    /// check whether the play is on the ground
    /// </summary>
    /// <returns></returns>
    private bool GroundedCheck()
    {
        return Physics2D.OverlapCircle(_circle_pos.position, _radius, _whatIsGround);
    }

    /// <summary>
    /// flip the player
    /// </summary>
    private void Flip()
    {
        Vector3 temp = this.transform.localScale;
        temp.x *= -1;
        this.transform.localScale = temp;
        isFacingRight = !isFacingRight;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //die from spike
        if (collision.gameObject.tag == "Spike" && !hasShield)
        {
            //play sound
            audioSource.PlayOneShot(dieClip, 10);

            //reborn
            StartCoroutine(RebornAfterSeconds());
        }

        //die from saw
        if (collision.gameObject.tag == "Saw")
        {
            //play sound
            audioSource.PlayOneShot(dieClip,10);

            //reborn
            StartCoroutine(RebornAfterSeconds());
        }

        //die from river
        if (collision.gameObject.tag == "River")
        {
            //play sound
            audioSource.PlayOneShot(dieClip,10);

            //reborn
            StartCoroutine(RebornAfterSeconds());
        }


        //pick up shield
        if (collision.gameObject.tag == "Shield")
        {
            shield.transform.rotation = Quaternion.Euler(shieldRotation);
            shield.transform.position = this.transform.position + Vector3.up * distanceOverHead;
            shield.transform.SetParent(this.transform);
            hasShield = true;
        }
    }

    //player reborn to last save point
    private void Reborn()
    {
        Transform rebornPoint = SavePointsManager.Instance.savePoints[SavePointsManager.Instance.savePoints.Count - 1];
        this.transform.position = rebornPoint.position;
    }

    IEnumerator RebornAfterSeconds()
    {
        yield return new WaitForSeconds(0.2f);
        Reborn();
    }

}
