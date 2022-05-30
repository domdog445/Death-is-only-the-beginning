using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricSparklez : MonoBehaviour
{

    public Transform target;

    [SerializeField]
    ParticleSystem partSys;

    [SerializeField]
    Color colorOff;

    [SerializeField]
    SpriteRenderer rendererf;

    float speed = 5f;
    bool Energy = true;
    void Update()
    {
        float currendDistance = Vector2.Distance(transform.position, target.position);
        transform.LookAt(target);
        if (currendDistance > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            IElectricComponent iE = target.GetComponent<IElectricComponent>();
            if (Energy)
                iE.TurnOn();
            else
                iE.TurnOff();
            partSys.Stop();
            Destroy(gameObject, 1.5f);
            Destroy(this);
        }
    }

    public void setTarget(Transform newTarget, bool newEnergy)
    {
        target = newTarget;
        Energy = newEnergy;
        var main = partSys.main;
        if(!newEnergy)
        {
            main.startColor = colorOff;
            rendererf.color = colorOff;
        }
       
    }
}
