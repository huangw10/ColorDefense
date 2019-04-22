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

    private void OnMouseEnter()
    {
        Debug.Log("aaaaa!");
        Game_manager.instance.revive.Invoke();
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
