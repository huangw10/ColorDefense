using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShooting : NetworkBehaviour
{
    public GameObject bullet;
    private float mouseAngle = 0;
    private Vector2 mouseDirection;
    private Player my_player;
    // Start is called before the first frame update
    void Start()
    {
        my_player = this.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hasAuthority)
        { 
            if (Input.GetMouseButtonUp(0))
            {
                mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                mouseAngle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
                CmdShoot(Quaternion.Euler(0.0f, 0.0f, mouseAngle));
            }
            if (Input.GetMouseButtonUp(1))
            {
                my_player.CmdDie();
                CmdShoot(Quaternion.Euler(0.0f, 0.0f, 0f));
                CmdShoot(Quaternion.Euler(0.0f, 0.0f, 45f));
                CmdShoot(Quaternion.Euler(0.0f, 0.0f, 90f));
                CmdShoot(Quaternion.Euler(0.0f, 0.0f, 135f));
                CmdShoot(Quaternion.Euler(0.0f, 0.0f, 180f));
                CmdShoot(Quaternion.Euler(0.0f, 0.0f, 225f));
                CmdShoot(Quaternion.Euler(0.0f, 0.0f, 270f));
                CmdShoot(Quaternion.Euler(0.0f, 0.0f, 315f));

            }
        }

    }
    
    [Command]
    public void CmdShoot(Quaternion a)
    {
        SoundManager.instance.shotting.Invoke();
        GameObject x = GameObject.Instantiate(bullet, this.transform.position, a);
        NetworkServer.Spawn(x);
    }
}
