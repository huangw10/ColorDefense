using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Competitive_gamemanager : MonoBehaviour
{
    public UnityEvent leftwin;
    public UnityEvent rightwin;
    static public Competitive_gamemanager instance;
    public GameObject lpenal;
    public GameObject rpenal;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        leftwin.AddListener(endofgamel);
        rightwin.AddListener(endofgamer);
    }

    void endofgamel()
    {
        lpenal.SetActive(true);
        Time.timeScale = 0.0f;
    }

    void endofgamer()
    {
        rpenal.SetActive(true);
        Time.timeScale = 0.0f;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
