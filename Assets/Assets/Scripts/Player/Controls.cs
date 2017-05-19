﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{

    [Range(0, 10)]
    public float speed = 4f;
    RaycastHit hit;
    public LayerMask targetLayer;
    public Rigidbody myBody;
    public AudioSource healing;
    AudioSource healed;
    AudioSource cycleItems;
   // bool canUse = true; //the boolean that allows players to use items
   // int addHealth = 0;
    [HideInInspector]
    public Animator anim;
    public Animator reflectionAnim;
    float horizontal;
    float vertical;
    public static Transform _Player;
    static bool canDo = true;
    public Animator miniMapCamera;
    int miniMapSelect = 0;



    void Awake()
    {
        _Player = gameObject.transform;
    }


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(horizontal * Time.deltaTime * speed, vertical * Time.deltaTime * speed, 0);
        //if (horizontal != 0 || vertical != 0)
        //{
        //    Vector3 up = -myBody.velocity;
        //    transform.Translate(horizontal * Time.deltaTime * speed, vertical * Time.deltaTime * speed, 0);
        //    PlayerAnimation();
        //    if (Physics.Raycast(transform.position, up, targetLayer))
        //    {
        //        print("There is something in front of the object!");
        //    }
        //    Debug.DrawRay(transform.position, up, Color.white);
        //}
        //else
        //{
        //    anim.SetBool("isWalking", false);
        //    reflectionAnim.SetBool("isWalking", false);
        //}
        //accessing character stats
        if (Input.GetKeyDown("c") && canDo)
        {
            canDo = false;
            if (!GameManagerScript.isActive)
            {
                StopAllCoroutines();
                speed = 0;
                PlayerStatSounds.on.Play();
                StartCoroutine(StatsIn());
            }
            else
            {
                PlayerStatSounds.off.Play();
                StartCoroutine(StatsOut());
            }
        }
        //accessing the inventory
        if (Input.GetKeyDown("i") && canDo)
        {
            canDo = false;
            if (GameManagerScript.isActive)
            {
                StopAllCoroutines();
                StartCoroutine(FadeOut());
            }
            else
            {
                UI.inventory.SetActive(true);
                speed = 0;
                StopAllCoroutines();
                StartCoroutine(FadeIn());
            }
        }
        //altering the mini map
        if (Input.GetKeyDown("m") && canDo)
        {
            canDo = false;
            StopAllCoroutines();
            StartCoroutine(MiniMap());

        }
    }//end of update

    //void PlayerAnimation()
    //{//animating the player's movement and the player's mirror reflection
    //    anim.SetBool("isWalking", true);
    //    reflectionAnim.SetBool("isWalking", true);
    //    anim.SetFloat("vertical", vertical);
    //    anim.SetFloat("horizontal", horizontal);
    //    reflectionAnim.SetFloat("horizontal", -horizontal);
    //    reflectionAnim.SetFloat("vertical", -vertical);
    //}




//the functions associated with the inventory
    IEnumerator FadeOut()
    {
        UI.UIevent.SetSelectedGameObject(null);
        while (Inventory.fade.alpha > 0)
        {
            yield return new WaitForSeconds(.01f);
            Inventory.fade.alpha -= .01f;
        }
        UI.inventory.SetActive(false);
        speed = PlayerStats.speed;
        canDo = true;
    }
    IEnumerator FadeIn()
    {
        while (Inventory.fade.alpha < 1)
        {
            yield return new WaitForSeconds(.01f);
            Inventory.fade.alpha += .01f;
            canDo = true;
        }
    }
    //the functions associated with the player stats
    IEnumerator StatsIn()
    {
        Animator anim = UI.playerStats.GetComponent<Animator>();
        UI.playerStats.SetActive(true);
        //playing the animations for the animator, but starting the animator where it last left off
        anim.Play("TurnOnStats", 0, 0);
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        canDo = true;
    }
    IEnumerator StatsOut()
    {

        Animator anim = UI.playerStats.GetComponent<Animator>();
        //playing the animations for the animator, but starting the animator where it last left off
        anim.Play("TurnOffStats", 0, 0);
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        UI.playerStats.SetActive(false);
        speed = PlayerStats.speed;
        canDo = true;
    }

    //the functions associated with the inventory
    IEnumerator MiniMap()
    {
        switch (miniMapSelect)
        {
            default:
                miniMapCamera.gameObject.SetActive(true);
                miniMapSelect++;
                break;
            case 1:
                miniMapCamera.Play("FullScreen", 0, 0);
                miniMapSelect++;
                break;
            case 2:
                miniMapCamera.Play("SmallScreen", 0, 0);
                miniMapSelect++;
                break;
            case 3:
                miniMapCamera.gameObject.SetActive(false);
                miniMapSelect = 0;
                break;
        }
        yield return new WaitForSeconds(.5f);
        canDo = true;
    }

}//end of class
