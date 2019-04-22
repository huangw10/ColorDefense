using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemymanager : MonoBehaviour
{
    static public Enemymanager instance;
    public UnityEvent EnemyDied;
    [SerializeField]private int EnemyWave;
    private int EnemyCount;
    private int EnemyPoint = 6;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        EnemyCount = EnemyPoint * EnemyWave;
        EnemyDied.AddListener(Enemybeenkilled);
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
