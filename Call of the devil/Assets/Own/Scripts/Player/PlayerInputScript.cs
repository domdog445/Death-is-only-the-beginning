using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{

    private Rigidbody2D rb;
    PlayerInput playerInput;

    float direction = 0f;

    Animator animator;

    [SerializeField]
    ParticleSystem partSys;

    [SerializeField]
    AudioSource audiosource;

    [SerializeField]
    PhysicsMaterial2D WalkMaterial;
    [SerializeField]
    PhysicsMaterial2D notWalkMaterial;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();

    }


    float maxspeed = 5;
    // Update is called once per frame
    void FixedUpdate()
    {

        
        rb.AddForce(new Vector2(direction * movespeed, 0), ForceMode2D.Impulse);
        if (Mathf.Abs(rb.velocity.x) > maxspeed)
        {
            if(rb.velocity.x >0)
                rb.AddForce(-new Vector2(rb.velocity.x - maxspeed, 0), ForceMode2D.Impulse);
            else
                rb.AddForce(-new Vector2(rb.velocity.x + maxspeed, 0), ForceMode2D.Impulse);
        }
        if ((direction < 0 && rb.velocity.x > -1) ||
            (direction > 0 && rb.velocity.x < 1))
        {
            rb.AddForce(-new Vector2(rb.velocity.x/4, 0), ForceMode2D.Impulse);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            rb.AddForce(Vector2.up * 7f, ForceMode2D.Impulse);
            partSys.Play();
            audiosource.Play();
        }

    }

    [SerializeField]
    GameOverController goController;
    public void PauseGame(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            goController.PauseGame();
        }

    }


    float movespeed = 0.65f;
    public void Movement_performed(InputAction.CallbackContext context)
    {
        
        direction = context.ReadValue<float>();
        animator.SetFloat("Direction",direction);
        if (context.performed)
        {
            
            rb.AddForce(new Vector2(direction * movespeed / 2, 0), ForceMode2D.Impulse);
        }
            
        if (direction == 0)
            rb.sharedMaterial = notWalkMaterial;
        else 
            rb.sharedMaterial = WalkMaterial;

        //    rb.AddForce(-rb.velocity, ForceMode2D.Impulse);

    }
}
