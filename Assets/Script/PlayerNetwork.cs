using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour
{
    // Start is called before the first frame update
    public GameObject playerobject;
    void Start()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        CmdSpawnplayer();
    }
    [Command]
    public void CmdSpawnplayer()
    {
        GameObject player = Instantiate(playerobject);
        NetworkServer.Spawn(player);
        player.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
