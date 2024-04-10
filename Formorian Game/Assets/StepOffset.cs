using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class StepOffset : MonoBehaviour 
{
    private float stepHeight = .25f, stepJump = 1f; // height that can be automatically jumped over;

    public float StepHeight // getsetter done through stats
    {
        get { return stepHeight; } set { stepHeight = value; }
    }
    public float StepJump // getsetter done through stats
    {
        get { return stepJump; }
        set { stepJump = value; }
    }
    private void Start() // check to see if they have a statblock, grab stepping values, if not, keep base.
    {
        try
        {
            if(!transform.parent.TryGetComponent(out StatScript statBlock))
            {
                Debug.LogException(new System.NullReferenceException("Error: Statblock not found to allocate stepping variables")); 
            }
            else
            {
                //Debug.Log(statBlock.stats[StatBlock.Stats.stepHeight]);
                StepHeight = statBlock.stats[StatBlock.Stats.stepHeight];
                StepJump = statBlock.stats[StatBlock.Stats.stepJump];
            }
        }
        catch(KeyNotFoundException)
        {
            Debug.LogError("Key wasn't added in Statblock");
        }
        catch (System.Exception)
        {
            Debug.Log("Unknown event occurred.");
            throw;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground")) // if it is a step
        {
            Vector2 location = new Vector2(this.transform.position.x, this.transform.position.y + StepHeight);

            RaycastHit2D stepCheck = Physics2D.Raycast(location, Vector2.right, .45f, LayerMask.NameToLayer("Player")); // will flip since sprite flips when moving left
            Debug.DrawRay(location, Vector2.right *.45f, Color.red, 5f);

            if(stepCheck.collider == null) // did not hit the step
            {
                transform.parent.position = new Vector2(this.transform.parent.position.x, this.transform.position.y +1.45f);
            }
        }
    }
}
