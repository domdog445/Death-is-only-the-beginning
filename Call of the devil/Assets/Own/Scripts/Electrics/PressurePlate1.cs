using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate1 : MonoBehaviour
{
    [SerializeField]
    Sprite spriteOn;
    [SerializeField]
    Sprite spriteOff;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    bool canTurnOff = false;

    [SerializeField]
    public IElectricComponent GoalComponent;
    [SerializeField]
    public GameObject GoalGameObject;

    [SerializeField]
    AudioSource audioSourceOn;
    [SerializeField]
    AudioSource audioSourceOff;

    private void Awake()
    {
        GoalComponent = GoalGameObject.GetComponent<IElectricComponent>();
    }


    IEnumerator showGameOverMenu()
    {
       
        yield return new WaitForSecondsRealtime(1.4f);
        ElectricSparklezController.SpawnParticls(transform, GoalGameObject.transform, false);
        spriteRenderer.sprite = spriteOff;
        audioSourceOff.Play();
        turnedon = false;
    }

    List<GameObject> gameObjects = new List<GameObject>();

    bool turnedon = false;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.CompareTag("Player"))
            return;
        gameObjects.Remove(collision.attachedRigidbody.gameObject);

        if(gameObjects.Count==0)
        {
            
            StopAllCoroutines();
            StartCoroutine(showGameOverMenu());

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.CompareTag("Player"))
            return;

        if (gameObjects.Count == 0)
        {
            if(!turnedon)
            {
                ElectricSparklezController.SpawnParticls(transform, GoalGameObject.transform, true);
                spriteRenderer.sprite = spriteOn;
                audioSourceOn.Play();
                turnedon = true;
            }
            
        }

        gameObjects.Add(collision.attachedRigidbody.gameObject);
        if (!canTurnOff)
            Destroy(this);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, GoalGameObject.transform.position);
    }

}
