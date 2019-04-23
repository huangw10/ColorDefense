using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class Game_manager : NetworkBehaviour
{
    // Start is called before the first frame update
    public UnityEvent revive;
    static public Game_manager instance;
    public GameObject player;
    public GameObject[] playerlist;

    private void Awake()
    {
        instance = this;
        revive.AddListener(revive_player);
    }

    void revive_player()
    {
        player.SetActive(true);
        player.GetComponent<Player>().set_tomb_status();


    }
    void Start()
    {
        playerlist = GameObject.FindGameObjectsWithTag("Player");

    }

    // Update is called once per frame
    
    void Update()
    {
        playerlist = GameObject.FindGameObjectsWithTag("Player");
    }
}
