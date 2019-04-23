using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tomb : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void revived()
    {
        Debug.Log("aaaaa!");
        Player.SetActive(true);
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
