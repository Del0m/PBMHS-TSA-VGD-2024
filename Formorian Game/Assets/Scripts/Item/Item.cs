using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool visible; // visible to player
    public StatBlock block;
    private Dictionary<StatBlock.Stats, float> stat = new Dictionary<StatBlock.Stats, float>();

    private void Start()
    {
        InitializeStat();
    }

    private void InitializeStat()
    {
        for(int i = 0; i < block.stat.Count; i++)
        {
            stat.Add(block.stat[i], block.values[i]);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // look for player, buff player
    {
        if(collision.CompareTag("Player"))
        {
            var statCount = stat.Count;

            for (int i = 0; i < statCount; i++)
            {
                try
                {
                    collision.gameObject.GetComponent<PlayerStatScript>().AddStat(block.stat[i], stat[block.stat[i]]); // buff player's stats accordingly
                }
                catch (System.Exception)
                {
                    Debug.LogError("Buff not found. Check player stats and item buff.");
                    throw;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
