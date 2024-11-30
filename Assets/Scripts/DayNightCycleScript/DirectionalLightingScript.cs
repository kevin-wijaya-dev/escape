using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class DirectionalLightingScript : MonoBehaviour
{
    private Transform directionalLight;
    private Material sky;

    //How long is one day in seconds (Day and Night) Default: 300f
    [SerializeField]private float dayTimeInSeconds = 300f;
    private float rotationalAngle = 0f;
    private float periodTime = 0f;
    private float sinWaveAngle = 0f;
    [SerializeField]private bool doDayNightCycle = true; //Here just in case it will be used

    private void Start() {
       directionalLight = transform;
       rotationalAngle = 360f/dayTimeInSeconds*0.02f;
       sky = RenderSettings.skybox;
    }

    void FixedUpdate()
    {
        if(doDayNightCycle){
            periodTime += Time.fixedDeltaTime;
            if(periodTime>=dayTimeInSeconds) periodTime -= dayTimeInSeconds;
            float progress = periodTime / dayTimeInSeconds;
            sinWaveAngle = Mathf.Deg2Rad * progress * 360f;
            // if(sinWaveAngle>=360) sinWaveAngle-=360;
            float wave = (Mathf.Sin((Mathf.PI/2)*Mathf.Sin(sinWaveAngle))+1)/2;
            sky.SetFloat("_TimeOfDay",wave);
            directionalLight.Rotate(Vector3.right,rotationalAngle);
        }
    }
}
