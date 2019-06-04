using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player_Shooting_competitive : NetworkBehaviour
{
    // Start is called before the first frame update
    public GameObject attacker;
    public GameObject balls;
    public GameObject ball2;
    public GameObject attacker2;
    public float coolDownTime = 3f;
    [SerializeField] string newtag;
    [SerializeField] string newtag2;
    [SerializeField] float adder;
    private SpriteRenderer spriteRenderer;
    private float timer;
    void Start() {
        timer = 0f;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.color = Color.red;
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

        timer -= Time.deltaTime;
        if(timer > 0f) return;
        spriteRenderer.color = Color.red;

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
    public void CmdShoot(int num) {
        RpcShoot();
        GameObject x;
        if (num == 1)
        {
            x = GameObject.Instantiate(balls, new Vector3(attacker.transform.position.x + adder, attacker.transform.position.y, 0), new Quaternion());
        }
        else
        {
            x = GameObject.Instantiate(ball2, new Vector3(attacker2.transform.position.x, attacker2.transform.position.y, 0), new Quaternion());
        }
        NetworkServer.Spawn(x);
    }

    [ClientRpc]
    public void RpcShoot() {
        timer = coolDownTime;
        spriteRenderer.color = Color.white;
    }

}
