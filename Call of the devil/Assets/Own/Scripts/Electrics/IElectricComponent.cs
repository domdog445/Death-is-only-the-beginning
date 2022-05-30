using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IElectricComponent
{
    public void TurnOn();
    public void TurnOff();
    public Vector2 getPos();
}
