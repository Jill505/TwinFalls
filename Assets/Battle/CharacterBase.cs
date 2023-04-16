using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase:MonoBehaviour
{
    public float hp;
    public Rigidbody2D rb;
    public Collider2D col;
    public Camera camera;
    Transform myTF;

    public float moveSpeed;
    public float jumpForce = 10f;

    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        col = gameObject.GetComponent<Collider2D>();
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        myTF = gameObject.GetComponent<Transform>();
    }

    public virtual void fire()
    {
        Debug.Log(gameObject + "µo®g¤l¼u");
    }

    public virtual void usingSkill()
    {
        
    }

    public virtual void kill()
    {
        Destroy(gameObject);
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(1* moveSpeed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-1 * moveSpeed, rb.velocity.y);
        }
        /*
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, -1 * moveSpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, 1 * moveSpeed);
        }*/
        /*
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }*/
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(0f,rb.velocity.y);
        }

        jump();

        //facing
        /*
        float diraction;
        Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Debug.Log("mouse pos is" + mousePos);
        Vector2 calXY = ((Vector2)transform.position - mousePos).normalized;
        diraction = Mathf.Atan2(calXY.y, calXY.x) * Mathf.Rad2Deg;
        Debug.Log("the dir is:" + diraction);
        transform.localEulerAngles = new Vector3(0f, 0f, diraction);*/
        Vector2 mouseDirection;
        Vector2 mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 AimDirection = mousePosition - rb.position;
        float AimAngle = Mathf.Atan2(AimDirection.y, AimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = AimAngle;
        
    }

    public void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Jump
            rb.velocity += new Vector2(0f,1f*jumpForce);
        }
    }
}