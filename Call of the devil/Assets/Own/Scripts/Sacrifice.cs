using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacrifice : MonoBehaviour
{

    Rigidbody2D rb;
    Collider2D col;

    ParticleSystem partsys;
    [SerializeField]
    SpriteRenderer spriterend;

    [SerializeField]
    GameObject SoulPref;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        partsys = GetComponent<ParticleSystem>();
        
    }


    public void Die()
    {
        GameObject go = Instantiate(SoulPref, transform.position, transform.rotation);
        Destroy(gameObject, 2);
        spriterend.enabled = false;
        rb.gravityScale = 0;
        rb.Sleep();
        col.enabled = false;
        partsys.Play();
        DevilMovement.addSacrificePos(go);
    }
}
