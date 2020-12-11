using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [Header("Horizontal Movement")]
    public float moveSpeed = 10f;
    public Vector2 direction;
    private bool facingRight = true;

    [Header("Vertical Movement")]
    public float jumpSpeed = 15f;
    public float jumpDelay = 0.25f;
    private float jumpTimer;

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;
    public LayerMask groundLayer;
    public GameObject characterHolder;

    [Header("Physics")]
    public float maxSpeed = 7f;
    public float linearDrag = 4f;
    public float gravity = 1f;
    public float fallMultiplier = 5f;
    public float onGroundFriction = 20f;

    [Header("Collision")]
    public bool onGround = false;
    public bool onWallLeft = false;
    public bool onWallRight = false;
    public float groundLength = 0.6f;
    public float sideLength = 0.2f;
    public Vector3 colliderOffset;

    // Update is called once per frame
    void Update() 
    {
        float horizontal3 = Input.GetAxisRaw("Horizontal");
        bool wasOnGround = onGround;
        onGround = Physics2D.Raycast(transform.position + new Vector3(0.12f, 0, 0) + colliderOffset, Vector2.down, groundLength, groundLayer) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);
        
        onWallLeft = Physics2D.Raycast(transform.position + new Vector3(-1f, 0.3f, 0), transform.position + new Vector3(-1f, 0.3f, 0) + Vector3.left, sideLength* 3 , groundLayer) ||
            Physics2D.Raycast(transform.position + new Vector3(-1f, -0.3f, 0), transform.position + new Vector3(-1f, -0.3f, 0) + Vector3.left, sideLength*3, groundLayer); 
        
        onWallRight = Physics2D.Raycast(transform.position + new Vector3(0.2f, 0.3f, 0), transform.position + new Vector3(0.5f, 0.3f, 0) + Vector3.right, sideLength, groundLayer) ||
            Physics2D.Raycast(transform.position + new Vector3(0.2f, -0.3f, 0), transform.position + new Vector3(0.5f, -0.3f, 0) + Vector3.right, sideLength, groundLayer);

        onWallMethod();

        if (onGround)
        {
            rb.sharedMaterial.friction = onGroundFriction;
        }
        else
        {
            rb.sharedMaterial.friction = 0.0f;
        }

        if (onGround && horizontal3 == 0)
        {
            //pysäytys tähän
        }

        if(!wasOnGround && onGround)
        {
            StartCoroutine(JumpSqueeze(1.25f, 0.8f, 0.05f));
        }

        if(Input.GetButtonDown("Jump"))
        {
            jumpTimer = Time.time + jumpDelay;
        }
        animator.SetBool("onGround", onGround);
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));   
    }

    void FixedUpdate() 
    {
        moveCharacter(direction.x);
        if(jumpTimer > Time.time && onGround)
        {
            Jump();
        }
        modifyPhysics();
    }

    void onWallMethod()
    {
    }

    void moveCharacter(float horizontal) {
        float horizontalmovement = Input.GetAxisRaw("Horizontal");

        if (onWallLeft && horizontalmovement > 0)
        {
            if (onGround)
            {    
                rb.AddForce(Vector2.right * horizontal * moveSpeed);
                animator.SetTrigger("onGround1");
            }
            else
            {
                rb.AddForce(Vector2.right * horizontal * moveSpeed * 1.5f);
            }
        }

        if (onWallRight && horizontalmovement < 0)
        {
            if (onGround)
            {    
                rb.AddForce(Vector2.right * horizontal * moveSpeed);
                animator.SetTrigger("onGround1");
            }
            else
            {
                rb.AddForce(Vector2.right * horizontal * moveSpeed * 1.5f);
            } 
        }

        if(!onWallLeft && !onWallRight)
        {
            if (onGround)
            {    
                rb.AddForce(Vector2.right * horizontal * moveSpeed);
                animator.SetTrigger("onGround1");
            }
            else
            {
                rb.AddForce(Vector2.right * horizontal * moveSpeed * 1.5f);
            }
        }

        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight)) {
            Flip();
        }

        if (Mathf.Abs(rb.velocity.x) > maxSpeed) {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }
        animator.SetFloat("horizontal", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("vertical", rb.velocity.y);
    }
    void Jump()
    {
        float horizontal2 = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(rb.velocity.x, 0);

        if(horizontal2 == 0f)
        {
            rb.AddForce(Vector2.up * jumpSpeed * 1.2f, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }

        jumpTimer = 0;
        StartCoroutine(JumpSqueeze(0.5f, 1.2f, 0.1f));
    }

    void modifyPhysics() {
        bool changingDirections = (direction.x > 0 && rb.velocity.x < 0) || (direction.x < 0 && rb.velocity.x > 0);

        if(onGround){
            if (Mathf.Abs(direction.x) < 0.4f || changingDirections) 
            {
                rb.drag = linearDrag;
            } else {
                rb.drag = 0f;
            }
            rb.gravityScale = 0;
        }else{
            rb.gravityScale = gravity;
            rb.drag = linearDrag * 0.15f;
            if(rb.velocity.y < 0){
                rb.gravityScale = gravity * fallMultiplier;
            }else if(rb.velocity.y > 0 && !Input.GetButton("Jump")){
                rb.gravityScale = gravity * (fallMultiplier);
            }
        }
    }
    void Flip() {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }
    IEnumerator JumpSqueeze(float xSqueeze, float ySqueeze, float seconds) {
        Vector3 originalSize = Vector3.one;
        Vector3 newSize = new Vector3(xSqueeze, ySqueeze, originalSize.z);
        float t = 0f;
        while (t <= 1.0) {
            t += Time.deltaTime / seconds;
            //characterHolder.transform.localScale = Vector3.Lerp(originalSize, newSize, t);
            yield return null;
        }
        t = 0f;
        while (t <= 1.0) {
            t += Time.deltaTime / seconds;
            //characterHolder.transform.localScale = Vector3.Lerp(newSize, originalSize, t);
            yield return null;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + new Vector3(0.12f, 0, 0) + colliderOffset, transform.position +new Vector3(0.12f, 0, 0) +colliderOffset + Vector3.down * groundLength);
        Gizmos.DrawLine(transform.position + new Vector3(0.12f, 0, 0) - colliderOffset, transform.position + new Vector3(0.12f, 0, 0) - colliderOffset + Vector3.down * groundLength);
        Gizmos.DrawLine(transform.position + new Vector3(-1f, -0.3f, 0), transform.position + new Vector3(-1f, -0.3f, 0) + Vector3.left * sideLength * 3);
        Gizmos.DrawLine(transform.position + new Vector3(0.2f, -0.3f, 0), transform.position + new Vector3(0.5f, -0.3f, 0) + Vector3.right * sideLength);
        Gizmos.DrawLine(transform.position + new Vector3(-1f, 0.3f, 0), transform.position + new Vector3(-1f, 0.3f, 0) + Vector3.left * sideLength * 3);
        Gizmos.DrawLine(transform.position + new Vector3(0.2f, 0.3f, 0), transform.position + new Vector3(0.5f, 0.3f, 0) + Vector3.right * sideLength);
    }
}