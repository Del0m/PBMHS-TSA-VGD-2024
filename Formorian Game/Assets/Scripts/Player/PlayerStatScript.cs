using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatScript : EntityStatScript
{
    public override void Start()
    {
        base.Start();
        CurrentHP = stats[StatBlock.Stats.health];

    }

    public override void HealthCheck(float val)
    {
        try
        {
            var healthPercent = val / stats[StatBlock.Stats.health] * 100;
            UIController.XScaleUI(GameObject.FindGameObjectWithTag("Healthbar"), healthPercent);

            if(val <= 0)
            {
                Debug.Log("Dead!");
                StartCoroutine(End());
            }
        }
        catch (System.Exception)
        {
            throw new System.Exception("Healthbar not found.");
        }

    }
    IEnumerator End() // pop up end screen, reset level.
    {
        UIController.UIPopUp(GameObject.FindGameObjectWithTag("End Screen"), true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
