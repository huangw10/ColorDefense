using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    // Start is called before the first frame update
    [SerializeField] private float moveSpeed;
    private Rigidbody2D m_rigidbody;
    private Player m_status;

    private void Awake()
    {
        m_rigidbody = this.GetComponent<Rigidbody2D>();
        m_status = this.GetComponent<Player>();
    }
    
  

    // Update is called once per frame
    void Update()
    {
        if (m_status.check_alive())
        {
            m_rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxisRaw("Vertical") * moveSpeed);
        }
    }
}
