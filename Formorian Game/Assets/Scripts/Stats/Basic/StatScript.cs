//armin delmo
// initalizes values from StatBlock, and passes to children scripts.
// not to be used on entities
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatScript : MonoBehaviour
{
    public Dictionary<StatBlock.Stats, float> stats = new Dictionary<StatBlock.Stats, float>(); // stores all stats for modification
    public StatBlock statBlock; // base stats to get

    public virtual void Start() // add all stats into stats dictionary
    {
        for (int i = 0; statBlock.stat.Count > i; i++)
        {
            stats.Add(statBlock.stat[i], statBlock.values[i]);
        }
        
        /* DEBUG FOR READING STATS
        foreach (KeyValuePair<StatBlock.Stats, float> kvp in stats)
        {
            Debug.Log(kvp.Key + " " + kvp.Value);
        }
        */
    }
    public void AddStat(StatBlock.Stats stat, float modifier) // changes a stat using +/-
    {
        stats[stat] += modifier;
    }
}
