using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    public GameObject target;
    private Rigidbody2D e_rigid;
    // Start is called before the first frame update
    private void Awake()
    {
        e_rigid = this.GetComponent<Rigidbody2D>();
    }

    void FollowTarget(GameObject target)
    {
        e_rigid.velocity = (target.transform.position - this.transform.position).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget(target);
    }
}
