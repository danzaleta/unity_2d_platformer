using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Rigidbody2D enemyRb;
    SpriteRenderer enemySpriteRend;
    Animator enemyAnim;
    ParticleSystem enemyParticle;
    AudioSource enemyDead;

    float timeBeforeChange;
    
    public float delay;
    public float speed;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemySpriteRend = GetComponent<SpriteRenderer>();
        enemyAnim = GetComponent<Animator>();
        enemyParticle = GameObject.Find("EnemyParticle").GetComponent<ParticleSystem>();
        enemyDead = GetComponentInParent<AudioSource>();
    }

    void Update()
    {
        enemyRb.velocity = Vector2.right * speed;

        if (speed > 0)
            enemySpriteRend.flipX = false;
        else if (speed < 0)
            enemySpriteRend.flipX = true;

        if (timeBeforeChange < Time.time)
        {
            speed *= -1;
            timeBeforeChange = Time.time + delay;
        }      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(transform.position.y + .03f < collision.transform.position.y)
            {
                enemyAnim.SetBool("isDead", true);
            }
        }
    }

    public void DisableEnemy()
    {
        enemyParticle.transform.position = new Vector2(transform.position.x, transform.position.y + 1f);
        enemyParticle.Play();
        enemyDead.Play();
        gameObject.SetActive(false);
    }
}
