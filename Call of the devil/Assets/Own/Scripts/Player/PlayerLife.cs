using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    PlayerInputScript playerInputScript;
    Rigidbody2D rb;
    Collider2D col;

    [SerializeField]
    ParticleSystem diePartsys;
    [SerializeField]
    SpriteRenderer spriterend;
    [SerializeField]
    AudioSource audiosource;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        playerInputScript = GetComponent<PlayerInputScript>();
    }

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(3, 6);
        Physics2D.IgnoreLayerCollision(7, 6);
        Physics2D.IgnoreLayerCollision(3, 8);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Devil"))
        {

            Die();
            
        }
    }

    private void Die()
    {
        audiosource.Play();
        Destroy(playerInputScript);
        spriterend.enabled = false;
        rb.gravityScale = 0;
        rb.Sleep();
        col.enabled = false;
        diePartsys.Play();
        GameOverController.GameOverScreen();
    }
}
