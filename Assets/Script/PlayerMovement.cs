using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour

{
    // Start is called before the first frame update
    [SerializeField] private float moveSpeed;
    private Rigidbody2D m_rigidbody;

    private void Awake()
    {
        m_rigidbody = this.GetComponent<Rigidbody2D>();
  
    }
    
  

    // Update is called once per frame
    void Update()
    {
        if (hasAuthority == false)
        {
            return;
        }
        
            m_rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxisRaw("Vertical") * moveSpeed);
    }
}
