using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D enemyRb;
    SpriteRenderer enemySpriteRend;
    Animator enemyAnim;
    float timeBeforeChange;
    public float delay = 0.5f;
    public float speed = .3f;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemySpriteRend = GetComponent<SpriteRenderer>();
        enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.velocity = Vector2.right * speed;
        if (speed < 0)
            enemySpriteRend.flipX = true;
        else if (speed > 0)
            enemySpriteRend.flipX = false;

        //Time.time es el tiempo que a pasado desde que nuestra aplicacion empezo
        if(timeBeforeChange < Time.time)
        {
            speed *= -1;
            timeBeforeChange = Time.time + delay;
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (transform.position.y + .3 < collision.transform.position.y)
            {
                enemyAnim.SetBool("isDead",true);
            }
        }

    }
    public void DisableEnemy()
    {
        gameObject.SetActive(false);
    }
}
