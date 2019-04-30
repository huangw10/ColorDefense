using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class Enemymanager : NetworkBehaviour
{
    static public Enemymanager instance;
    public UnityEvent EnemyDied;
    public UnityEvent EnemySpawn;
    [SerializeField] private int EnemyWave;
    private int EnemyCount;
    private int EnemyPointCount;
    public GameObject panel;
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
        SoundManager.instance.StartBGM.Invoke();
        CmdStartBGM();
        EnemyPointCount = pointlist.Length;
        EnemyCount = EnemyPointCount * EnemyWave;
        EnemyDied.AddListener(Enemybeenkilled);
        ini_enemy = true;
    }

    void Enemybeenkilled()
    {
        EnemyCount--;
        Debug.Log(EnemyCount);
        if (EnemyCount == 0)
        {
            if(isServer)
            RpcEndgame();
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
            EnemySpawn.Invoke();
            RpcStartSpawn();
            for (int i = 0; i < EnemyPointCount; i++)
            {
                GameObject a = GameObject.Instantiate(Enemy_prefab, pointlist[i].transform.position, new Quaternion());
                NetworkServer.Spawn(a);

            }
            yield return new WaitForSeconds(betweenWave);
        }
    }
    [ClientRpc]
    void RpcEndgame()
    {
        Time.timeScale = 0.0f;
        panel.SetActive(true);
    }
    [Command]
    void CmdStartBGM()
    { SoundManager.instance.StartBGM.Invoke();
        RpcStartBGM(); }
    [ClientRpc]
    void RpcStartBGM()
    {
        SoundManager.instance.StartBGM.Invoke();
    }
    [ClientRpc]
    void RpcStartSpawn()
    {
        EnemySpawn.Invoke();
    }
    
}
