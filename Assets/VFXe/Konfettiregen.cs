using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Konfettiregen : MonoBehaviour
{
    public ParticleSystem[] Konfetti;

    public void Update()
    {
        if(Input.GetKey("a"))
        {
            KonfettiregenGo();
        }
    }

    public void KonfettiregenGo()
    {


        foreach(ParticleSystem vfx in Konfetti)
        {
            vfx.Play();
        }
    }

}
