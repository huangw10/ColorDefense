using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{

    // Start is called before the first frame update
    Text a;
    void Awake()
    {
        a = this.GetComponent<Text>();
        Competitive_gamemanager.instance.leftwin.AddListener(leftw);
        Competitive_gamemanager.instance.rightwin.AddListener(rightw);
    }

    void leftw()
    {
        a.text = "Left Player Won!";
    }

    void rightw()
    {
        a.text = "Right Player Won!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
