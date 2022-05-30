using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacrificeManager : MonoBehaviour
{
    public static SacrificeManager singleton;
    [SerializeField]
    SacrificeCollision player;


    Coroutine cor;
    private void Awake()
    {
        singleton = GetComponent<SacrificeManager>();
    }

    public static void NotificateAll(bool val)
    {
        singleton.player.setSacrificeState(val);
        if(val)
        {
            singleton.StopAllCoroutines();
            singleton.StartCoroutine(singleton.ResetNotification());
        }
    }

    IEnumerator ResetNotification()
    {
        yield return new WaitForSeconds(2);

        NotificateAll(false);
    }


}
