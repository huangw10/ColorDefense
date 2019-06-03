using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject related_Player;
    [SerializeField] string newtag;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        related_Player = GameObject.FindWithTag(newtag);
        if (related_Player != null)
            this.transform.position = new Vector3(-related_Player.transform.position.x, this.transform.position.y, 0);
    }
}
