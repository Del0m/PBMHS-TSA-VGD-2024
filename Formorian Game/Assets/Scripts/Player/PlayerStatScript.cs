using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatScript : EntityStatScript
{
    public override void Start()
    {
        base.Start();
        CurrentHP = stats[StatBlock.Stats.health];

    }
    public override void HealthCheck()
    {
        var healthPercent = CurrentHP / stats[StatBlock.Stats.health] * 100;
        UIController.XScaleUI(GameObject.FindGameObjectWithTag("Healthbar"), healthPercent);
    }
}
