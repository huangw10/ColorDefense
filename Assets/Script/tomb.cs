using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class tomb : NetworkBehaviour
{
    public GameObject m_player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void revived()
    {
        Debug.Log("aaaaa!");
        m_player.SetActive(true);
        m_player.GetComponent<Player>().tomb_status = true;
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
}
