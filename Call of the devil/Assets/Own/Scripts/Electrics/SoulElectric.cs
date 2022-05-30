using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulElectric : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody == null)
            return;
        SoulSwitch sw = collision.attachedRigidbody.GetComponent<SoulSwitch>();

        if (sw != null)
        {
            sw.Switchtatus();
        }
    }
}
