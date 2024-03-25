using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem trailEffect;

    //Play trail effect as long as board is in contact with the slope
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "RestartZone")
        {
            trailEffect.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.tag == "RestartZone")
        {
            trailEffect.Stop();
        }
    }

}
