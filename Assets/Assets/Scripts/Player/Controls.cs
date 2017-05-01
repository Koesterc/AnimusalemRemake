using UnityEngine;
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



    void Start()
    {
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

}//end of class
