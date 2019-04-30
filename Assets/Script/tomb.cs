using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class tomb : NetworkBehaviour
{
    public GameObject m_player;
    static public int num_tomb = 0;
    // Start is called before the first frame update
    void Start()
    {
        num_tomb += 1;
        if (num_tomb == NetworkManager.singleton.numPlayers)
        {
            if(isServer)
            RpcEndgame1();
        }
    }

    public void revived()
    {
        Debug.Log("aaaaa!");
        m_player.SetActive(true);
        m_player.GetComponent<Player>().tomb_status = true;
        num_tomb -= 1;
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    [Command]
    public void Cmdrevived()
    {
        revived();
        Rpcrevived(m_player);
    }
    [ClientRpc]
    public void Rpcrevived(GameObject a)
    {
        m_player = a;
        revived();
    }
    [ClientRpc]
    public void RpcEndgame1()
    {
        Time.timeScale = 0.0f;
        Enemymanager.instance.panel.SetActive(true);
    }
}
