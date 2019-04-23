using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyMovement : NetworkBehaviour
{
    [SerializeField] private float speed;
    private GameObject target;
    private Rigidbody2D e_rigid;
    private bool is_walk = true;
    private float avoid_time_count = 0f;
    public int identity;
    private Color[] colorlist= { Color.blue, Color.red, Color.green, Color.yellow} ;
    // Start is called before the first frame update
    private void Awake()
    {
        e_rigid = this.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (isServer)
        {
            int num = NetworkManager.singleton.numPlayers;
            int a = Random.Range(1, num + 1);

            identity = a;
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = colorlist[identity - 1];
            Rpcindentity(a);
        }
    }

    GameObject decide_whotofollow(GameObject[] player_list)
    {
        float x = 10000f;
        for (int i = 0; i < player_list.Length; i++)
        {
            float d = Vector3.Distance(player_list[i].transform.position, this.transform.position);
            if (d < x)
            {
                x = d;
            }
        }
        for (int i = 0; i < player_list.Length; i++)
        {
            float d = Vector3.Distance(player_list[i].transform.position, this.transform.position);
            if (d == x)
            {
                return player_list[i];
            }

        }
        return null;
    }

    void FollowTarget(GameObject target)
    {
        e_rigid.velocity = (target.transform.position - this.transform.position).normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            avoid_time_count = 0f;
            is_walk = false;
       //     Vector3 a = target.transform.position - this.transform.position;
       //     e_rigid.velocity = new Vector3(a.y, a.x, a.z).normalized * speed * 3;
            if(target != null)
                 e_rigid.velocity = Quaternion.Euler(0f,0f,90f)* (target.transform.position - this.transform.position).normalized * speed * 3;

        }
    }

    // Update is called once per frame
    void Update()
    {
        target = decide_whotofollow(Game_manager.instance.playerlist);
        if (target != null && is_walk)
        { FollowTarget(target); }
        else if (target != null && !is_walk)
        {
            if (avoid_time_count <= 0.5f)
                avoid_time_count += 1 * Time.deltaTime;
            else
            {
                avoid_time_count = 0f;
                is_walk = true;
            }


        }
        else
        { }
    }
    [ClientRpc]
    public void Rpcindentity(int a)
    {
        identity = a;
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = colorlist[identity - 1];
    }
}
