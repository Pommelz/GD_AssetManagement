using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Collectable : MonoBehaviour
{

    [SerializeField]
    private string[] lootTags = new string[0];

    private void OnTriggerEnter(Collider other)
    {
        foreach (var tag in lootTags)
        {
            if (this.gameObject.tag == tag)
            {
                CollectLoot(this.gameObject);
            }

        }
    }

    private void CollectLoot(GameObject loot)
    {
        switch (loot.tag)
        {
            case "Gold":
                CollectGold();

                break;
            default:
                break;
        }
        Destroy(loot);
    }

    private void CollectGold()
    {
        
    }

}
