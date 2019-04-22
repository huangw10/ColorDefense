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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            Enemymanager.instance.EnemyDied.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f));
    }
}
