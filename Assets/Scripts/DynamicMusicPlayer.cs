using Unity.Mathematics;
using UnityEngine;

public class DynamicMusicPlayer : MonoBehaviour
{
    //audio sources
    [SerializeField] AudioSource chordsA;
    [SerializeField] AudioSource chordsB;
    [SerializeField] AudioSource breakcoreLoopA;
    [SerializeField] AudioSource breakcoreLoopB;
    [SerializeField] AudioSource melody1A;
    [SerializeField] AudioSource melody1B;
    [SerializeField] AudioSource melody2A;
    [SerializeField] AudioSource melody2B;
    [SerializeField] AudioSource drumLoop1A;
    [SerializeField] AudioSource drumLoop1B;
    [SerializeField] AudioSource drumLoop2A;
    [SerializeField] AudioSource drumLoop2B;

    //

    //
    public float fadeSpeed;
    public float maxVolume;
    //

    //audio determiners//
    private GameObject plr;
    private float distFromWall;
    private PlayerMotor playerMotor;

    public GameObject deathWall;
    //

    public bool swapMelody;
    public bool swapDrums;
    void Start()
    {
        plr = ServiceHubManager.Instance.player;
        playerMotor = plr.GetComponent<PlayerMotor>();
        StartAllTracks();
        DontDestroyOnLoad(this);
        RandomizeTracks();
        EventBus.RequestEvent("RequestRoundStart", true).ping += RandomizeTracks;
        
    }
    private void RandomizeTracks()
    {
        swapMelody = UnityEngine.Random.value > 0.5f;
        swapDrums = UnityEngine.Random.value > 0.5f;
    }

    private void StartAllTracks()
    {
        double dspCur = AudioSettings.dspTime - 4; // -3 is cause im lazy
        double halfTime = 5 + (chordsA.clip.length / 2);
        chordsA.PlayScheduled(dspCur + 5);
        chordsB.PlayScheduled(dspCur + halfTime);

        melody1A.PlayScheduled(dspCur + 5);
        melody1B.PlayScheduled(dspCur + halfTime);

        melody2A.PlayScheduled(dspCur + 5);
        melody2B.PlayScheduled(dspCur +halfTime);

        drumLoop1A.PlayScheduled(dspCur + 5);
        drumLoop1B.PlayScheduled(dspCur +halfTime);

        drumLoop2A.PlayScheduled(dspCur + 5);
        drumLoop2B.PlayScheduled(dspCur + halfTime);

        breakcoreLoopA.PlayScheduled(dspCur + 5);
        breakcoreLoopB.PlayScheduled(dspCur + halfTime);
    }

    private void PlayChillMix()
    {
        chordsA.volume = Mathf.MoveTowards(chordsA.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);
        chordsB.volume = Mathf.MoveTowards(chordsB.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);
        if(swapMelody)
        {
        melody1A.volume = Mathf.MoveTowards(melody1A.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        melody1B.volume = Mathf.MoveTowards(melody1B.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);

        melody2A.volume = Mathf.MoveTowards(melody2A.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);
        melody2B.volume = Mathf.MoveTowards(melody2B.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);
        }
        else
        {
        melody1A.volume = Mathf.MoveTowards(melody1A.volume,maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        melody1B.volume = Mathf.MoveTowards(melody1B.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);

        melody2A.volume = Mathf.MoveTowards(melody2A.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        melody2B.volume = Mathf.MoveTowards(melody2B.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        }
        if(swapDrums)
        {
        drumLoop1A.volume = Mathf.MoveTowards(drumLoop1A.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        drumLoop1B.volume = Mathf.MoveTowards(drumLoop1B.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);

        drumLoop2A.volume = Mathf.MoveTowards(drumLoop2A.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);
        drumLoop2B.volume = Mathf.MoveTowards(drumLoop2B.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);
        }
        else
        {
        drumLoop1A.volume = Mathf.MoveTowards(drumLoop1A.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);
        drumLoop1B.volume = Mathf.MoveTowards(drumLoop1B.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);

        drumLoop2A.volume = Mathf.MoveTowards(drumLoop2A.volume,maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        drumLoop2B.volume = Mathf.MoveTowards(drumLoop2B.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        }
    }
    private void PlayMovingMix()
    {
        chordsA.volume = Mathf.MoveTowards(chordsA.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);
        chordsB.volume = Mathf.MoveTowards(chordsB.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);
        if(swapMelody)
        {
        melody1A.volume = Mathf.MoveTowards(melody1A.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        melody1B.volume = Mathf.MoveTowards(melody1B.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);

        melody2A.volume = Mathf.MoveTowards(melody2A.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);
        melody2B.volume = Mathf.MoveTowards(melody2B.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);
        }
        else
        {
        melody1A.volume = Mathf.MoveTowards(melody1A.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        melody1B.volume = Mathf.MoveTowards(melody1B.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);

        melody2A.volume = Mathf.MoveTowards(melody2A.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        melody2B.volume = Mathf.MoveTowards(melody2B.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        }

        drumLoop1A.volume = Mathf.MoveTowards(drumLoop1A.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        drumLoop1B.volume = Mathf.MoveTowards(drumLoop1B.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);

        drumLoop2A.volume = Mathf.MoveTowards(drumLoop2A.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        drumLoop2B.volume = Mathf.MoveTowards(drumLoop2B.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        
    }
    private void PlayMovingMixInclusive()
    {
        chordsA.volume = Mathf.MoveTowards(chordsA.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        chordsB.volume = Mathf.MoveTowards(chordsB.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        
        melody1A.volume = Mathf.MoveTowards(melody1A.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        melody1B.volume = Mathf.MoveTowards(melody1B.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);

        melody2A.volume = Mathf.MoveTowards(melody2A.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        melody2B.volume = Mathf.MoveTowards(melody2B.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        
        
        drumLoop1A.volume = Mathf.MoveTowards(drumLoop1A.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        drumLoop1B.volume = Mathf.MoveTowards(drumLoop1B.volume, maxVolume, fadeSpeed * Time.deltaTime);

        drumLoop2A.volume = Mathf.MoveTowards(drumLoop2A.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        drumLoop2B.volume = Mathf.MoveTowards(drumLoop2B.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        
    }
    private void PlayMenuMusic()
    {
        chordsA.volume = Mathf.MoveTowards(chordsA.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        chordsB.volume = Mathf.MoveTowards(chordsB.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        breakcoreLoopA.volume = 0;
        breakcoreLoopB.volume = 0;
        if(swapMelody)
        {
        melody1A.volume = Mathf.MoveTowards(melody1A.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        melody1B.volume = Mathf.MoveTowards(melody1B.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);

        melody2A.volume = Mathf.MoveTowards(melody2A.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);
        melody2B.volume = Mathf.MoveTowards(melody2B.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);
        }
        else
        {
        melody1A.volume = Mathf.MoveTowards(melody1A.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);
        melody1B.volume = Mathf.MoveTowards(melody1B.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);

        melody2A.volume = Mathf.MoveTowards(melody2A.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        melody2B.volume = Mathf.MoveTowards(melody2B.volume, maxVolume, fadeSpeed * Time.unscaledDeltaTime);
        }
        if(swapDrums)
        {
        drumLoop1A.volume = Mathf.MoveTowards(drumLoop1A.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);
        drumLoop1B.volume = Mathf.MoveTowards(drumLoop1B.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);

        drumLoop2A.volume = Mathf.MoveTowards(drumLoop2A.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);
        drumLoop2B.volume = Mathf.MoveTowards(drumLoop2B.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);
        }
        else
        {
        drumLoop1A.volume = Mathf.MoveTowards(drumLoop1A.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);
        drumLoop1B.volume = Mathf.MoveTowards(drumLoop1B.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);

        drumLoop2A.volume = Mathf.MoveTowards(drumLoop2A.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);
        drumLoop2B.volume = Mathf.MoveTowards(drumLoop2B.volume, 0f, fadeSpeed * Time.unscaledDeltaTime);
        }
    }

    void Update()
    {
        if(UnityEngine.Random.Range(0,1000) >= 999)
        {
            RandomizeTracks();
        }
        if(ServiceHubManager.Instance.gameStateManager._currentState != GameStates.Gameplay)
        {
            PlayMenuMusic();
            return;
        }

        if(plr.transform.position.x - deathWall.transform.position.x < 30f)
        {
            float dist = plr.transform.position.x - deathWall.transform.position.x;

            float targ = Mathf.InverseLerp(30f, 0f, dist);

            breakcoreLoopA.volume = Mathf.Lerp(breakcoreLoopA.volume, targ, 0.1f);
            breakcoreLoopB.volume = Mathf.Lerp(breakcoreLoopB.volume, targ, 0.1f);
        }   

        if(playerMotor.momentum.magnitude > 0.05f)
        {
            PlayMovingMix();
        }
        else
        {
            PlayChillMix();
        }
    }

} 
