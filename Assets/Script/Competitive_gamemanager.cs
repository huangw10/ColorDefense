﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Competitive_gamemanager : MonoBehaviour
{
    public UnityEvent leftwin;
    public UnityEvent rightwin;
    static public Competitive_gamemanager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}