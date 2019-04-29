using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class Enemymanager : NetworkBehaviour
{
    static public Enemymanager instance;
    public UnityEvent EnemyDied;
    [SerializeField] private int EnemyWave;
    private int EnemyCount;
    private int EnemyPointCount;
    public GameObject Enemy_prefab;
    public GameObject[] pointlist;
    private bool ini_enemy=false;
    [SerializeField] private float timer;
    [SerializeField] private float betweenWave;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
    }

    public override void OnStartServer()
    {
        EnemyPointCount = pointlist.Length;
        EnemyCount = EnemyPointCount * EnemyWave;
        EnemyDied.AddListener(Enemybeenkilled);
        ini_enemy = true;
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
        if (ini_enemy)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 20)
        {
            IniEnemy();
            ini_enemy = false;
            timer = 0f;
        }
        
    }
    
    
    void IniEnemy()
    {
        Debug.Log("a");
        StartCoroutine(GenerateAllEnemies());
    }

    private IEnumerator GenerateAllEnemies() {
        for (int j = 0; j < EnemyWave; j++) {
            for (int i = 0; i < EnemyPointCount; i++)
            {
                GameObject a = GameObject.Instantiate(Enemy_prefab, pointlist[i].transform.position, new Quaternion());
                NetworkServer.Spawn(a);

            }
            yield return new WaitForSeconds(betweenWave);
        }
    }
}
