using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game_manager : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent revive;
    static public Game_manager instance;
    public GameObject player;

    private void Awake()
    {
        instance = this;
        revive.AddListener(revive_player);
    }

    void revive_player()
    {
        player.SetActive(true);


    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
