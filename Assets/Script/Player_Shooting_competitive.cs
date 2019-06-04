using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player_Shooting_competitive : NetworkBehaviour
{
    // Start is called before the first frame update
    public GameObject attacker;
    public GameObject balls;
    public GameObject attacker2;
    [SerializeField] string newtag;
    [SerializeField] string newtag2;
    [SerializeField] float adder;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attacker = GameObject.FindWithTag(newtag);
        attacker2 = GameObject.FindWithTag(newtag2);
        if (hasAuthority == false)
        {
            return;
        }

        if (attacker != null)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                CmdShoot(1);
            }
        }
        if (attacker2 != null)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                CmdShoot(2);
            }
        }
        else
            Debug.Log("cannot find tag");
    }

    [Command]
    public void CmdShoot(int num)
    {
        GameObject x;
        if (num == 1)
        {
            x = GameObject.Instantiate(balls, new Vector3(attacker.transform.position.x + adder, attacker.transform.position.y, 0), new Quaternion());
            x.GetComponent<Balls>().ish = true;
        }
        else
        {
            x = GameObject.Instantiate(balls, new Vector3(attacker2.transform.position.x, attacker2.transform.position.y, 0), new Quaternion());
            x.GetComponent<Balls>().ish = false;
        }
        NetworkServer.Spawn(x);
    }

}
