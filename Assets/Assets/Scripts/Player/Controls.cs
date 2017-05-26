using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{

    public static float speed = 4f;
    RaycastHit hit;
    public LayerMask targetLayer;
    public Rigidbody myBody;
    public AudioSource healing;
    AudioSource healed;
    AudioSource cycleItems;
   // bool canUse = true; //the boolean that allows players to use items
   // int addHealth = 0;
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
        speed = PlayerStats.speed;
    }


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(horizontal * Time.deltaTime * speed, vertical * Time.deltaTime * speed, 0);
        if (horizontal != 0 || vertical != 0)
        {
            Vector3 up = -myBody.velocity;
            transform.Translate(horizontal * Time.deltaTime * speed, vertical * Time.deltaTime * speed, 0);
            PlayerAnimation();
            if (Physics.Raycast(transform.position, up, targetLayer))
            {
                print("There is something in front of the object!");
            }
            Debug.DrawRay(transform.position, up, Color.white);
        }
        else
        {
            anim.SetBool("isWalking", false);
            reflectionAnim.SetBool("isWalking", false);
        }


        //accessing character stats
        if (Input.GetKeyDown("c") && canDo)
        {
            if (!GameManagerScript.isActive)
            {
                canDo = false;
                StopAllCoroutines();
                speed = 0;
                PlayerStatSounds.on.Play();
                StartCoroutine(StatsIn());
            }
            else if (GameManagerScript.isActive && UI.playerStats.activeSelf)
            {
                canDo = false;
                PlayerStatSounds.off.Play();
                StartCoroutine(StatsOut());
            }
        }
        //accessing the inventory
        if (Input.GetKeyDown("i") && canDo)
        {
            if (GameManagerScript.isActive && UI.inventory.activeSelf)
            {
                canDo = false;
                StopAllCoroutines();
                StartCoroutine(FadeOut());
            }
            else if (!GameManagerScript.isActive)
            {
                canDo = false;
                speed = 0;
                StopAllCoroutines();
                StartCoroutine(FadeIn());
            }
        }
        //altering the mini map
        if (Input.GetKeyDown("m") && canDo && !GameManagerScript.isActive)
        {
            canDo = false;
            StopAllCoroutines();
            StartCoroutine(MiniMap());
        }
    }//end of update

    //Player Animations
    void PlayerAnimation()
    {//animating the player's movement and the player's mirror reflection
        anim.SetBool("isWalking", true);
      //  reflectionAnim.SetBool("isWalking", true);
        anim.SetFloat("vertical", vertical);
        anim.SetFloat("horizontal", horizontal);
      //  reflectionAnim.SetFloat("horizontal", -horizontal);
      //  reflectionAnim.SetFloat("vertical", -vertical);
    }

    //the functions associated with the inventory
    IEnumerator FadeOut()
    {
        UI.UIevent.SetSelectedGameObject(null);
        UI.screenEffect.Play("FadeOut");
        UI.screenEffect.speed = 4;
        yield return new WaitForSeconds(.5f);
        UI.inventory.SetActive(false);
        UI.screenEffect.Play("FadeIn");
        yield return new WaitForSeconds(.5f);
        UI.screenEffect.speed = 1;
        speed = PlayerStats.speed;
        switch (miniMapSelect)
        {
            case 0:
                yield return null;
                break;
            default:
                miniMapCamera.gameObject.SetActive(true);
                break;
        }
        canDo = true;
        anim.speed = 1;
        anim.enabled = true;
    }
    IEnumerator FadeIn()
    {
        miniMapCamera.gameObject.SetActive(false);
        anim.speed = 0;
        anim.enabled = false;
        UI.screenEffect.Play("FadeOut");
        UI.screenEffect.speed = 4;
        yield return new WaitForSeconds(.5f);
        UI.inventory.SetActive(true);
        UI.screenEffect.Play("FadeIn");
        yield return new WaitForSeconds(.5f);
        UI.screenEffect.speed = 1;
        canDo = true;
    }
    //the functions associated with the player stats
    IEnumerator StatsIn()
    {
        anim.speed = 0;
        anim.enabled = false;
        miniMapCamera.gameObject.SetActive(false);
        Animator temp = UI.playerStats.GetComponent<Animator>();
        UI.playerStats.SetActive(true);
        //playing the animations for the animator, but starting the animator where it last left off
        temp.Play("TurnOnStats", 0, 0);
        yield return new WaitForSeconds(temp.GetCurrentAnimatorStateInfo(0).length);
        canDo = true;
    }
    IEnumerator StatsOut()
    {

        Animator temp = UI.playerStats.GetComponent<Animator>();
        //playing the animations for the animator, but starting the animator where it last left off
        temp.Play("TurnOffStats", 0, 0);
        yield return new WaitForSeconds(temp.GetCurrentAnimatorStateInfo(0).length);
        UI.playerStats.SetActive(false);
        speed = PlayerStats.speed;
        switch (miniMapSelect)
        {
            case 0:
                yield return null;
                break;
            default:
                miniMapCamera.gameObject.SetActive(true);
                break;
        }
        canDo = true;
        anim.enabled = true;
        anim.speed = 1;
    }

    //the functions associated with the inventory
    IEnumerator MiniMap()
    {
        switch (miniMapSelect)
        {
            default:
                miniMapCamera.gameObject.SetActive(true);
                miniMapSelect++;
                canDo = true;
                yield return null;
                break;
            case 1:
                miniMapCamera.Play("FullScreen", 0, 0);
                miniMapSelect++;
                yield return new WaitForSeconds(.5f);
                canDo = true;
                break;
            case 2:
                miniMapCamera.Play("SmallScreen", 0, 0);
                miniMapSelect++;
                yield return new WaitForSeconds(.5f);
                canDo = true;
                break;
            case 3:
                miniMapCamera.gameObject.SetActive(false);
                miniMapSelect = 0;
                canDo = true;
                yield return null;
                break;
        }
    }
}//end of class
