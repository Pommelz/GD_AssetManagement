using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject Konfetti;
    public GameManager GM;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GM.Check = true;
            Konfetti.SetActive(true);
        }
        
       
    }

}
