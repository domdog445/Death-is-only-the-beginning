using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulSwitch : MonoBehaviour
{
    [SerializeField]
    public IElectricComponent GoalComponent;
    [SerializeField]
    public GameObject GoalGameObject;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    ParticleSystem partSys;

    [SerializeField]
    Sprite TurnOnSprite;
    [SerializeField]
    Sprite TurnOffSprite;

    [SerializeField]
    SpriteRenderer renderer;

    private void Awake()
    {
        GoalComponent = GoalGameObject.GetComponent<IElectricComponent>();
    }


    bool turnon = false;

    public void Switchtatus()
    {
        if(turnon)
        {
            turnon = false;
            turnOff();
        }
        else
        {
            turnon = true;
            turnOn();
        }
    }
    public void turnOn()
    {
        ElectricSparklezController.SpawnParticls(transform, GoalGameObject.transform, true);
        //GoalComponent.TurnOn();
        audioSource.Play();
        partSys.Play();
        renderer.sprite = TurnOnSprite;
    }
    public void turnOff()
    {
        ElectricSparklezController.SpawnParticls(transform, GoalGameObject.transform, false);
        //GoalComponent.TurnOn();
        audioSource.Play();
        partSys.Stop();
        renderer.sprite = TurnOffSprite;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, GoalGameObject.transform.position);
    }
}
