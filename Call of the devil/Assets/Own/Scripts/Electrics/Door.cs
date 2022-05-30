using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IElectricComponent
{
    [SerializeField]
    Transform PositionOffTransform;
    [SerializeField]
    Transform PositionOnTransform;

    Vector3 PositionOff;
    Vector3 PositionOn;

    [SerializeField]
    float speed = 2;

    [SerializeField]
    AudioSource audiosource;

    Vector2 GoalPosition;

    private void Start()
    {
        GoalPosition = transform.position;
        PositionOff = PositionOffTransform.position;
        PositionOn = PositionOnTransform.position;

    }

    

    private void Update()
    {
        float currendDistance = Vector2.Distance(transform.position, GoalPosition);

        if (currendDistance > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, GoalPosition, speed * Time.deltaTime);
        }
    }


    public void TurnOn()
    {
        GoalPosition = PositionOn;
        audiosource.Play();
    }
    public void TurnOff()
    {
        GoalPosition = PositionOff;
        audiosource.Play();
    }

    public Vector2 getPos()
    {
        return transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(PositionOffTransform.position, PositionOnTransform.position);
    }

}

