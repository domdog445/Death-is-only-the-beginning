using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricSparklezController : MonoBehaviour
{
    static ElectricSparklezController singleton;

    [SerializeField]
    GameObject ElictricSparklezPref;

    private void Awake()
    {
        singleton = GetComponent<ElectricSparklezController>();
    }

    public static void SpawnParticls(Transform StartPos, Transform Target, bool EnergyType)
    {
        singleton.spawnParticlez(StartPos, Target, EnergyType);
    }

    public void spawnParticlez(Transform StartPos, Transform Target,bool EnergyType)
    {
        GameObject go = Instantiate(ElictricSparklezPref, StartPos.position, StartPos.rotation);
        ElectricSparklez ESparkls = go.GetComponent<ElectricSparklez>();
        ESparkls.setTarget(Target, EnergyType);
        go.transform.LookAt(Target.position);
    }

}
