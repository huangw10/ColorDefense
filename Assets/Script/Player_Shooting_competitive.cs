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
        attacker = GameObject.FindWithTag(newtag);
        if (hasAuthority == false)
        {
            return;
        }

        if (attacker != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CmdShoot();
            }
        }
        else
            Debug.Log("cannot find tag");
    }

    [Command]
    public void CmdShoot()
    {
        GameObject x = GameObject.Instantiate(balls, new Vector3(attacker.transform.position.x + adder, this.transform.position.y, 0), new Quaternion());
        NetworkServer.Spawn(x);
    }
}
