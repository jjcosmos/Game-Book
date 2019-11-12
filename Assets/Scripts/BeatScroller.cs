﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;
    public bool hasStarted;
    void Start()
    {
        beatTempo = beatTempo / 60;
    }


    void Update()
    {
        if (hasStarted) { 
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
        
    }
}
