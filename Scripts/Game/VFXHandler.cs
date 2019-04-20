using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXHandler : MonoBehaviour
{
    ParticleSystem chargeParticles;

    // Start is called before the first frame update
    void Start()
    {
        chargeParticles = GetComponentInChildren<ParticleSystem>();
    }

    //add code to keep neutral rotation and start and stop calls
}
