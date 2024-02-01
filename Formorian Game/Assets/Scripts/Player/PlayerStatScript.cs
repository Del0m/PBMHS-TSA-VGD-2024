using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
            // tick the player to red.
            StartCoroutine(Hurt());

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
    IEnumerator Hurt() // turn red, then back to normal
    {
        var sprite = GetComponent<SpriteRenderer>();
        sprite.color = UnityEngine.Color.red;
        yield return new WaitForSeconds(.15f);
        sprite.color = UnityEngine.Color.white;
    }
}
