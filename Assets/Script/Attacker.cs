using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Attacker : NetworkBehaviour
{
    public GameObject related_Player;
    // Start is called before the first frame update
    void Start()
    {
    }
        // Update is called once per frame
        void Update()
    {
        related_Player = GameObject.FindWithTag("xyz");
        if (related_Player != null)
        this.transform.position = new Vector3(this.transform.position.x, related_Player.transform.position.y, 0); 
    }
}
