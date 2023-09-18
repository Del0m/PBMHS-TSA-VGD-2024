//armin delmo
// initalizes values from StatBlock, and passes to children scripts.
// not to be used on entities
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatScript : MonoBehaviour
{
    public Dictionary<StatBlock.Stats, float> stats = new Dictionary<StatBlock.Stats, float>();
    public StatBlock statBlock;

    private void Start()
    {
        for(int i = 0; statBlock.stat.Count > i; i++)
        {
            stats.Add(statBlock.stat[i], statBlock.values[i]);
        }
        foreach(KeyValuePair<StatBlock.Stats, float> kvp in stats)
        {
            Debug.Log(kvp.Key + " " + kvp.Value );
        }
    }
}
