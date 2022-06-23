using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool grounded;
    [SerializeField] private float speed;
    private Animator anim;
    public float JumpForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horiz * speed, rb.velocity.y);
        
        if (horiz > 0.0f)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        else if (horiz < -0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        // if (horiz > 0 || horiz < 0)
        // {
        //     transform.localScale = new Vector2(1f * horiz, 1f);
        // }
        
        if(Input.GetKey(KeyCode.Space) && grounded )
        {
            //anim.SetTrigger("jump");
            Jump();
        }   
        anim.SetBool("walk", horiz != 0);
        anim.SetBool("grounded",grounded);
    }
   
    private void Jump()
    {
        rb.velocity = Vector2.up * JumpForce; 
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }

    private void Deactivated()
    {
        gameObject.SetActive(false);
    }
}