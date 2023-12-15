using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float jumpSpeed;

    private Rigidbody2D myRB;
    private SpriteRenderer pSprite;
    private BoxCollider2D coll;
    private Vector3 bottomLeftCorner;
    private Vector3 bottomRightCorner;
    private Vector3 initialPosition;
    private bool canDoubleJump;
    private bool didDoubleJump;
    private Animator playerAnimator;
    private float dirX;
    [SerializeField]private LayerMask groundLayer;
    public static PlayerMovement instance;

    public enum Movement{idle,running,jumping,doublejumping,falling}
    private void Awake() {
        if(instance == null)
        instance = this;
        else
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        coll= GetComponent<BoxCollider2D>();
        playerAnimator = GetComponent<Animator>();
        pSprite = GetComponent<SpriteRenderer>();
        initialPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        didDoubleJump=false;
        myRB.velocity = new Vector2(dirX * speed,myRB.velocity.y);
        myRB.transform.position = new Vector2(Mathf.Clamp(transform.position.x, bottomLeftCorner.x, bottomRightCorner.x), Mathf.Clamp(transform.position.y, bottomLeftCorner.y, bottomRightCorner.y));

        if(Input.GetKeyDown("space"))
        {
            if(IsGrounded())
                {myRB.velocity = new Vector2(myRB.velocity.x, jumpSpeed);canDoubleJump=true;}
            if(!IsGrounded()&&canDoubleJump)
                {myRB.velocity = new Vector2(myRB.velocity.x,jumpSpeed); canDoubleJump=false; didDoubleJump=true;}
               
        }
        PlayerAnimations();
    }
    private bool IsGrounded(){
        
         return Physics2D.BoxCast(coll.bounds.center, new Vector2(coll.bounds.size.x - 0.5f, coll.bounds.size.y), 0f, Vector2.down, .1f,groundLayer);
        
    }

     public void SetBounds(Vector3 botLeft, Vector3 topRight)
    {
        bottomLeftCorner = botLeft + new Vector3(0.5f,0.5f,0f);
        bottomRightCorner = topRight + new Vector3(-0.5f,-0.5f,0f);
    }

    public void PlayerAnimations(){
        

        if(dirX>.1f || dirX<-.1f){
                if(myRB.velocity.y ==0 || IsGrounded())
                playerAnimator.SetInteger("state",1);
                if(myRB.velocity.x<-.1f){
                    pSprite.flipX = true;
                }
                else pSprite.flipX = false;
        }
        if(myRB.velocity.y>.1f){
            playerAnimator.SetInteger("state",2);
            if(didDoubleJump){
                playerAnimator.SetInteger("state",4);
            }
        }
        if(myRB.velocity.y<-.1f){
            playerAnimator.SetInteger("state", 3);
            if(didDoubleJump){
                playerAnimator.SetInteger("state",4);
            }
        }
        if(myRB.velocity == new Vector2(0f,0f))
            {playerAnimator.SetInteger("state",0);}

    }


}

