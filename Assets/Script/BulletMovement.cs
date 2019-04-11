using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float moveSpeed;
    void Start()
    {
        
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f));
    }
}
