using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnscaledTimeParticle : MonoBehaviour
{

    void Start()
    {
        Material material = new Material(Shader.Find("UI/Particles/Hidden"));
    }

    void Update()
    {
        if (GetComponent<ParticleSystem>().main.loop == false)
        {
            if (Time.timeScale < 0.01f)
            {
                GetComponent<ParticleSystem>().Simulate(Time.unscaledDeltaTime, true, false);
            }
        }
        else if (GetComponent<ParticleSystem>().main.loop == true)
        {
            if (Time.timeScale < 0.01f)
            {
                GetComponent<ParticleSystem>().Simulate(Time.unscaledDeltaTime, true, false);
            }
            if (Time.timeScale > 0.01f)
            {
                GetComponent<ParticleSystem>().Simulate(Time.unscaledDeltaTime, true, false);
            }
        }
    }

}

