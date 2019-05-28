using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Competitive_player_connection : NetworkBehaviour
{
    // Start is called before the first frame update
    public GameObject playerobject;
    public GameObject playerobject2;
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
        if (NetworkManager.singleton.numPlayers == 2)
        {
            GameObject player = Instantiate(playerobject2, new Vector3(4, 0, 0), new Quaternion());//??????
            NetworkServer.Spawn(player);
            player.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);
        }
        else
        {
            GameObject player = Instantiate(playerobject, new Vector3(-4, 0, 0), new Quaternion());//??????
            NetworkServer.Spawn(player);
            player.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
