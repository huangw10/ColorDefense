using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallchange : MonoBehaviour
{
    // Start is called before the first frame update

    SpriteRenderer a;
    public AudioClip[] audiolist;
    AudioSource audioa;

    void Start()
    {
        a = this.GetComponentInChildren<SpriteRenderer>();
        audioa = this.GetComponent<AudioSource>();
    }

    void changeColor()
    {
        a.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ball"))
        {
            changeColor();
            audioa.clip = audiolist[Random.Range(0, 20)];
            audioa.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
