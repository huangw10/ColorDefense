﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Wall"))
        {
            speed = -speed;
        }
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x + speed * Time.deltaTime, this.transform.position.y, 0);
    }

}
