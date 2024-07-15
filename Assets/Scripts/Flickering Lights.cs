using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    [Header("Lights")]
    public Light spotLight;
    public Light pointLight;

    public float MinTime;
    public float MaxTime;
    public float Timer;

    void Start()
    {
        Timer = Random.Range(MinTime, MaxTime);
    }

    void Update()
    {
        FlickerLight();
    }

    void FlickerLight()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }

        if(Timer <= 0)
        {
            spotLight.enabled = !spotLight.enabled;
            pointLight.enabled = !pointLight.enabled;
            Timer = Random.Range(MinTime, MaxTime);
 
        }
    }

}
