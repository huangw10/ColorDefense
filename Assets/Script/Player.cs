﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool is_alive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void been_killed()
    {
        is_alive = false;
    }

    public void been_revive()
    {
        is_alive = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            been_killed();
            this.gameObject.SetActive(false);
        }
    }

    public bool check_alive()
    {
        return is_alive;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
