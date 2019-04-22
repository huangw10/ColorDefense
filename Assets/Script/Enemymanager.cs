using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemymanager : MonoBehaviour
{
    static public Enemymanager instance;
    public UnityEvent EnemyDied;
    [SerializeField] private int EnemyWave;
    private int EnemyCount;
    private int EnemyPointCount;
    public GameObject Enemy_prefab;
    public GameObject[] pointlist;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        EnemyPointCount = pointlist.Length;
        EnemyCount = EnemyPointCount * EnemyWave;
        EnemyDied.AddListener(Enemybeenkilled);
        IniEnemy();
    }

    void IniEnemy()
    {
        for (int i = 0; i < EnemyPointCount; i++)
        {
            GameObject.Instantiate(Enemy_prefab, pointlist[i].transform.position, new Quaternion());
        }
    }
    void Enemybeenkilled()
    {
        EnemyCount--;
        Debug.Log("Nice Shot");
        if (EnemyCount == 0)
        {
            Debug.Log("You Won");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
