using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] //<--make it visible in the inspector panel and not accessible in other classes -->
    private float movementSpeed = 10f, jumpSpeed = 10f;

    //Other components
    private float movementX;

    private Rigidbody2D myBody; //use drag and drop in unity while this is serialized or public to avoid errors
    private SpriteRenderer sr;

    private Animator anim;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>(); //get the component via code
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyBoard();
        AnimatePlayer();
        PlayerJump();
    }

    void PlayerMoveKeyBoard()
    {
        movementX = Input.GetAxisRaw("Horizontal"); //faster than .GetAxis
        transform.position += movementSpeed * Time.deltaTime * new Vector3(movementX, 0f, 0f); //formula for smooth movement
    }

    void AnimatePlayer() //player animation depending on the value of movementX
    {
        //going right
        if (movementX > 0)
        {
            sr.flipX = false; //to reset and go right
            anim.SetBool("Walk", true);
        } //going left set the transform to -1 (first way) || (second way) sprite renderer flip
        else if (movementX < 0)
        {
            sr.flipX = true; //to go to left
            anim.SetBool("Walk", true);
        } //stop
        else
        {
            anim.SetBool("Walk", false);
        }
    }

    void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myBody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }

}
