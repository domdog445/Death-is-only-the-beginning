using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacrificeCollision : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    AudioSource audiosource;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.collider.CompareTag("Sacrifice"))
        {
            

            for (int k = 0; k < collision.contacts.Length; k++)
            {
                if (Vector3.Angle(collision.contacts[k].normal, Vector3.up) <= 50)
                {
                    SacrificeManager.NotificateAll(true);
                    Sacrifice sacrifice = collision.collider.GetComponent<Sacrifice>();
                    if (sacrifice != null)
                    {
                        audiosource.Play();
                        sacrifice.Die();
                    }
                }
            }



            
                

        }
    }

    public void setSacrificeState(bool newVal)
    {
        animator.SetBool("Fear", newVal);
    }
}
