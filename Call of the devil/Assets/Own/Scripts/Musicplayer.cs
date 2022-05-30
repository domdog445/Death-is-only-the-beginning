using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicplayer : MonoBehaviour
{
    static Musicplayer singleton;
    void Start()
    {
        if (singleton != null)
            Destroy(gameObject);
        else
        {
            singleton = this;
            DontDestroyOnLoad(singleton);
        }
    }

    
}
