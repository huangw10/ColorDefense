using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player_Shooting_competitive : NetworkBehaviour
{
    // Start is called before the first frame update
    public GameObject attacker;
    public GameObject balls;
    [SerializeField] string newtag;
    [SerializeField] float adder;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasAuthority == false)
        {
            return;
        }

        attacker = GameObject.FindWithTag(newtag);
        if (attacker != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CmdShoot();
            }
        }
    }

    [Command]
    public void CmdShoot()
    {
        GameObject x = GameObject.Instantiate(balls, new Vector3(attacker.transform.position.x + adder, attacker.transform.position.y, 0), new Quaternion());
        NetworkServer.Spawn(x);
    }
}
