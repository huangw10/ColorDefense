using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Balls : NetworkBehaviour
{
    [SerializeField] private float speed;
    public bool ish = true;
    // Start is called before the first frame update
    void Start()
    {
        Competitive_gamemanager.instance.rightwin.AddListener(dest);
        Competitive_gamemanager.instance.leftwin.AddListener(dest);
    }

    public void dest()
    {
        Destroy(this);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            speed = -speed;
        }
        
        if (collision.CompareTag("Player") )
        {
            Competitive_gamemanager.instance.rightwin.Invoke();
        }

        if (collision.CompareTag("Player1+"))
        {
            Competitive_gamemanager.instance.leftwin.Invoke();
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (ish)
            this.transform.position = new Vector3(this.transform.position.x + speed * Time.deltaTime, this.transform.position.y, 0);
        else
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + speed * Time.deltaTime, 0);
    }

}
