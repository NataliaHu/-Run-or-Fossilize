using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Player : MonoBehaviour
{

    private Rigidbody rb;
    public int speed;
    public int jump;
    public Transform groundCheck;
    public Transform groundCheck_2;
    private bool LookingRight;
    private bool isGrounded;
    private bool isGrounded_2;

    private Animator anim;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float vida;




    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        LookingRight = true;

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
        lookingDirection();

    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, whatIsGround);
        isGrounded_2 = Physics.CheckSphere(groundCheck_2.position, checkRadius, whatIsGround);


        if (Input.GetButtonDown("Jump") && (isGrounded || isGrounded_2))
        {

            //rb.velocity = Vector3.up * jump;
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            Debug.Log("Entra");

        }

        if (!isGrounded && !isGrounded_2)
        {
            anim.SetBool("jump", true);
        }
        else
        {

            anim.SetBool("jump", false);
        }

        if (Input.GetAxis("Horizontal") != 0)
            if (LookingRight)
            {
                transform.eulerAngles = new UnityEngine.Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new UnityEngine.Vector3(0, -180, 0);
            }


    }



    /* this function set the value of the boolean LookingRight to true if the player is moving on 
     * the right axis and false if he is moving on the left
     */

    void lookingDirection()
    {

        if (Input.GetAxis("Horizontal") > 0)
            LookingRight = true;
        if (Input.GetAxis("Horizontal") < 0)

            LookingRight = false;

    }

    //geter for Looking right
    public bool getLookingRight()
    {
        return LookingRight;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeadZone")
        {
            vida--;
        }
    }
}
