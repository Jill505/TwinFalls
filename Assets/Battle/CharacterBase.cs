using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase:MonoBehaviour
{
    public float hp;
    public Rigidbody2D rb;
    public Collider2D col;
    public Camera camera;

    public float moveSpeed;

    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        col = gameObject.GetComponent<Collider2D>();
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
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
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, -1 * moveSpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, 1 * moveSpeed);
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(0f,rb.velocity.y);
        }

        //facing
        float diraction;
        Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector2 calXY = (Vector2)transform.position - mousePos;
        diraction = Mathf.Atan2(calXY.y, calXY.x) * 180f/Mathf.PI;
        transform.localEulerAngles = new Vector3(0f, 0f, diraction);
    }
}
