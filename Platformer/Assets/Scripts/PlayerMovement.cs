using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float speed = 1.1f;
    public float jumpForce = 220f;
    public Animator playerAnim;
    bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.velocity = new Vector2(Input.GetAxis("Horizontal")* speed, playerRb.velocity.y);
        if (Input.GetAxis("Horizontal") == 0)
        {
            playerAnim.SetBool("isWalking", false);
        }
        else if (Input.GetAxis("Horizontal") < 0 )
        {
            playerAnim.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            playerAnim.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }


    void Jump()
    {
        GetComponent<AudioSource>().Play();
        playerRb.AddForce(Vector2.up * jumpForce);
        isGrounded = false;
        playerAnim.SetTrigger("jump");
    }
}
