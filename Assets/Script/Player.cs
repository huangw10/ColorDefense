using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    private bool is_alive = true;
    public GameObject tomb;
    public bool tomb_status = true;
    private bool revive_people = false;
    [SerializeField] float revive_time = 2.0f;

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
    public void set_tomb_status()
    {
        tomb_status = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isServer)
        {
            if (collision.CompareTag("Tomb"))
            {
                //               if (Input.GetKey(KeyCode.R))
                //            {
                //               Debug.Log("Reviving");
                //               revive_time -= 1.0f * Time.deltaTime;

                //          }
                //           if (revive_time <= 0f)
                //           {
                //              collision.GetComponent<tomb>().Cmdrevived();
                //               revive_time = 2.0f;
                //   }
                collision.GetComponent<tomb>().m_player.GetComponent<Player>().tomb_status = true;
                collision.GetComponent<tomb>().Cmdrevived();
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tomb"))
        {
            revive_time = 2.0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isServer)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                //    been_killed();
                CmdDie();
            }
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

    [Command]
    public void CmdDie()
    {
        if (tomb_status)
        {

            tomb_status = false;
            Debug.Log("Player died");
            GameObject a = GameObject.Instantiate(tomb, this.transform.position, new Quaternion());
            a.GetComponent<tomb>().m_player = this.gameObject;
            NetworkServer.Spawn(a);
            is_alive = false;
            this.gameObject.SetActive(false);
            Rpcdie(a);
            

        }
    }

    [ClientRpc]
    public void Rpcdie(GameObject a)
    {
        if (tomb_status)
        {

            tomb_status = false;
            Debug.Log("Player died");
            a.GetComponent<tomb>().m_player = this.gameObject;
            is_alive = false;
            this.gameObject.SetActive(false);

        }
    }
}
