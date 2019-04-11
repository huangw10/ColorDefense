using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    // Start is called before the first frame update
    [SerializeField] private float moveSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0.0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0.0f), Space.World);
        transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0.0f, 0.0f), Space.World);
    }
}
