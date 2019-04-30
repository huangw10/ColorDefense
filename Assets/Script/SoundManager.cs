using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundManager : MonoBehaviour
{
    public AudioSource efSource;
    public AudioSource musicSource;
    public static SoundManager instance = null;
    public AudioClip SpawningAudio;
    public AudioClip e_die;
    public UnityEvent shotting;
    public AudioClip Shotting_Clip;
    public UnityEvent ReviveEvent;
    public AudioClip Revive_Clip;
    public AudioClip Death_Clip;
    public AudioClip BGMusic;
    public UnityEvent Death_Event;
    public UnityEvent StartBGM;

    public float low = 0.95f;
    public float high = 1.05f;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void PlayBGM()
    {
        musicSource.Play();
    }


    public void PlaySingle(AudioClip clip)
    {
        efSource.clip = clip;
        efSource.Play();
    }
    void Start()
    {
        Enemymanager.instance.EnemySpawn.AddListener(playSpawn);
        Enemymanager.instance.EnemyDied.AddListener(playDieofEnemy);
        this.shotting.AddListener(playShot);
        this.ReviveEvent.AddListener(playRevive);
        this.Death_Event.AddListener(PlayHLS);
        this.StartBGM.AddListener(PlayBGM);
        musicSource.clip = BGMusic;
    }
    public void PlayHLS()
    {
        PlaySingle(Death_Clip);
    }

    public void playRevive()
    {
        PlaySingle(Revive_Clip);
    }

    public void playShot()
    {

        PlaySingle(Shotting_Clip);
        
    }

    public void playDieofEnemy()
    {
        PlaySingle(e_die);
    }

    public void RandomizeSFX(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(low, high);
        efSource.pitch = randomPitch;
        efSource.clip = clips[randomIndex];
        efSource.Play();

    }


    void playSpawn()
    {
        PlaySingle(SpawningAudio);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
