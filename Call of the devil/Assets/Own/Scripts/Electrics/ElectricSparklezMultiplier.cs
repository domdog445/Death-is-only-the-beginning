using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricSparklezMultiplier : MonoBehaviour, IElectricComponent
{

    [SerializeField]
    List<GameObject> Goals = new List<GameObject>();

    public Vector2 getPos()
    {
        return transform.position;
    }

    public void TurnOff()
    {
        for(int i = 0; i < Goals.Count; i++)
        {
            ElectricSparklezController.SpawnParticls(transform, Goals[i].transform, false);
        }
    }

    public void TurnOn()
    {
        for (int i = 0; i < Goals.Count; i++)
        {
            ElectricSparklezController.SpawnParticls(transform, Goals[i].transform, true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < Goals.Count; i++)
        {
            Gizmos.DrawLine(transform.position, Goals[i].transform.position);
        }
        
    }
}
