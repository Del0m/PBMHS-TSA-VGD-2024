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
    public List<GameObject> UI; // hold buff UI

    public override void HealthCheck(float val, float prevHealth)
    {
        try
        {
            // tick the player to red.
            if(val > prevHealth)
            {
                StartCoroutine(Hurt());
            }

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

    int offset = 0;
    // addStat will change the UI
    public override void AddStat(StatBlock.Stats stat, float modifier)
    {
        base.AddStat(stat, modifier);
        // add the stat to the buff
        var obj = new GameObject();
        switch (stat)
        {
            case StatBlock.Stats.health: // add red bubble
                obj = Instantiate(UI[1], GameObject.FindGameObjectWithTag("Buff").transform);
                //obj.transform.position = new Vector3(50 * offset, 0, 0);
                obj.transform.SetParent(GameObject.FindGameObjectWithTag("Buff").transform);

                break;
            case StatBlock.Stats.damage: // add pink bubble
                break;
            case StatBlock.Stats.speed: // add blue bubble
                obj = Instantiate(UI[0]);
                obj.transform.position = new Vector3(100 * offset + 110, 890, 0);
                obj.transform.SetParent(GameObject.FindGameObjectWithTag("Buff").transform);

                break;
            case StatBlock.Stats.jumpPower: // add yellow bubble

                obj = Instantiate(UI[2], GameObject.FindGameObjectWithTag("Buff").transform);
                //obj.transform.position = new Vector3(50 * offset, 0, 0);
                obj.transform.SetParent(GameObject.FindGameObjectWithTag("Buff").transform);


                break;
        }
        Resources.UnloadUnusedAssets();
        offset++; // increment so if they get another buff, it won't occupy the same spot.
    }
}
