using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject actualMouse;
    [SerializeField]
    GameObject MousePref;

    // Update is called once per frame
    void Update()
    {
        if(actualMouse == null)
        {
            actualMouse = Instantiate(MousePref,transform.position,transform.rotation);
        }
    }
}
