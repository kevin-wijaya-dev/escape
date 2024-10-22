using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class DirectionalLightingScript : MonoBehaviour
{
    private Transform directionalLight;

    //How long is one day in seconds (Day and Night)
    private float dayTimeInSeconds = 300f;
    private float rotationalAngle = 0f;

    private void Start() {
       directionalLight = transform;
       rotationalAngle = 360f/dayTimeInSeconds*0.02f;
    }

    void FixedUpdate()
    {
        directionalLight.Rotate(Vector3.right,rotationalAngle);
    }
}
