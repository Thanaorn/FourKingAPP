using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class followMouse : MonoBehaviour
{
    public int speed;
    public int jump;
    Vector3 mousePos;
    private Animator animator;
    private float currentPos;
    private bool grounded;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        mousePos = transform.position;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, mousePos,speed*Time.deltaTime);
        if (currentPos< transform.position.x) {
            transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        currentPos = transform.position.x;
        if (Input.GetKey(KeyCode.Space) && grounded == true)
        {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jump);
        grounded = false;
    }
}
