using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    private float mouseAngle = 0;
    private Vector2 mouseDirection;
    private Player my_status;
    // Start is called before the first frame update
    void Start()
    {
        my_status = this.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (my_status.check_alive())
        {
            if (Input.GetMouseButtonUp(0))
            {
                mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                mouseAngle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
                GameObject.Instantiate(bullet, this.transform.position, Quaternion.Euler(0.0f,0.0f,mouseAngle));
            }
            if (Input.GetMouseButtonUp(1))
            {
                my_status.die();
                GameObject.Instantiate(bullet, this.transform.position, Quaternion.Euler(0.0f, 0.0f, 0f));
                GameObject.Instantiate(bullet, this.transform.position, Quaternion.Euler(0.0f, 0.0f, 45f));
                GameObject.Instantiate(bullet, this.transform.position, Quaternion.Euler(0.0f, 0.0f, 90f));
                GameObject.Instantiate(bullet, this.transform.position, Quaternion.Euler(0.0f, 0.0f, 135f));
                GameObject.Instantiate(bullet, this.transform.position, Quaternion.Euler(0.0f, 0.0f, 180f));
                GameObject.Instantiate(bullet, this.transform.position, Quaternion.Euler(0.0f, 0.0f, 225f));
                GameObject.Instantiate(bullet, this.transform.position, Quaternion.Euler(0.0f, 0.0f, 270f));
                GameObject.Instantiate(bullet, this.transform.position, Quaternion.Euler(0.0f, 0.0f, 315f));

            }
        }

    }
}
