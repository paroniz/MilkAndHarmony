using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public float xattackRadius = 1;
    public float yattackRadius = 0.5f;
    private Animator ani;
    Rigidbody2D rb;
    Rigidbody2D kingrb;
    GameObject king;
    float xdistanceBetween;
    float xdistanceBetween2;
    float ydistanceBetween;
    public float xchargeDistance = 4f;
    public float ychargeDistance = 0.8f;
    // public float chargeLimitLeft;
    // public float chargeLimitRight;
    public float chargeSpeed = 2;
    public float moveSpeed = -1;
    public bool dead = false;
    
    public float moveLimitLeft;

    public float moveLimitRight;
    public bool isCharging = false;
    //public bool facingRight;
    public float turnTimer = 2;
    public bool canTurn;
    

    void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        king = GameObject.Find("King");
        kingrb = king.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead && !isCharging)
        {
            this.GetComponent<Transform>().Translate(moveSpeed * Time.deltaTime, 0f, 0f);
        }

        if (!isCharging)
        {
            Turning();
        }

        xdistanceBetween = rb.transform.position.x - kingrb.transform.position.x;
        xdistanceBetween2 = Mathf.Abs(rb.transform.position.x - kingrb.transform.position.x);
        ydistanceBetween = Mathf.Abs(rb.transform.position.y) - Mathf.Abs(kingrb.transform.position.y);

        if(xdistanceBetween2 < xattackRadius && ydistanceBetween < yattackRadius )
        {
            Attack();
        }

        if(xdistanceBetween < xchargeDistance && ydistanceBetween < ychargeDistance && king.transform.position.x < moveLimitRight + 2 && king.transform.position.x > moveLimitLeft - 2)
        {
            isCharging = true;
            Charge();
        }
        else
        {
            isCharging = false;
        }

        //Debug.Log(rb.transform.rotation.y);
        TurnTimer();
    }

    void Attack()
    {
        ani.SetTrigger("Attack");
        Debug.Log("attacking");
        
    }

    void Charge()
    {
        if(xdistanceBetween > 0 && rb.transform.rotation.y < 0)
        {
            this.GetComponent<Transform>().Rotate(0f, 180f, 0f);
            //Debug.Log("turning");
        }

        if(xdistanceBetween < 0 && rb.transform.rotation.y > -1)
        {
            this.GetComponent<Transform>().Rotate(0f, 180f, 0f); 
            //Debug.Log("turning");
        }
        //Debug.Log("charging");
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(king.transform.position.x, transform.position.y), chargeSpeed * Time.deltaTime);
    }

    void Turning()
    {
        if (canTurn == true)
        {
            if (this.GetComponent<Transform>().position.x < moveLimitLeft)
            {    
                this.GetComponent<Transform>().Rotate(0f, 180f, 0f);
                canTurn = false;
                turnTimer = 2;
            }

            if (this.GetComponent<Transform>().position.x > moveLimitRight)
            {    
                this.GetComponent<Transform>().Rotate(0f, 180f, 0f);
                canTurn = false;
                turnTimer = 2;
            }
        }
    }

    void TurnTimer()
    {
        turnTimer -= Time.deltaTime;
        if(turnTimer <= 0f)
        {
            canTurn = true;
        }
    }
}
