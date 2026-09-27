using Unity.Mathematics;
using UnityEngine;

public class DynamicMusicPlayer : MonoBehaviour
{
    //audio sources
    [SerializeField] AudioSource chordsA;
    [SerializeField] AudioSource chordsB;
    [SerializeField] AudioSource breakcoreLoop;
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
    }

    private void StartAllTracks()
    {
        double dspCur = AudioSettings.dspTime - 3; // -3 is cause im lazy
        chordsA.PlayScheduled(dspCur + 5);
        chordsB.PlayScheduled(dspCur + 10.6470588);

        melody1A.PlayScheduled(dspCur + 5);
        melody1B.PlayScheduled(dspCur + 10.6470588);

        melody2A.PlayScheduled(dspCur + 5);
        melody2B.PlayScheduled(dspCur + 10.6470588);

        drumLoop1A.PlayScheduled(dspCur + 5);
        drumLoop1B.PlayScheduled(dspCur + 10.6470588);

        drumLoop2A.PlayScheduled(dspCur + 5);
        drumLoop2B.PlayScheduled(dspCur + 10.6470588);

        breakcoreLoop.PlayScheduled(dspCur + 5);
    }

    private void PlayChillMix()
    {
        chordsA.volume = Mathf.MoveTowards(chordsA.volume, 0f, fadeSpeed * Time.deltaTime);
        chordsB.volume = Mathf.MoveTowards(chordsB.volume, 0f, fadeSpeed * Time.deltaTime);
        breakcoreLoop.volume = Mathf.MoveTowards(breakcoreLoop.volume, 0f, fadeSpeed * Time.deltaTime);
        if(swapMelody)
        {
        melody1A.volume = Mathf.MoveTowards(melody1A.volume, maxVolume, fadeSpeed * Time.deltaTime);
        melody1B.volume = Mathf.MoveTowards(melody1B.volume, maxVolume, fadeSpeed * Time.deltaTime);

        melody2A.volume = Mathf.MoveTowards(melody2A.volume, 0f, fadeSpeed * Time.deltaTime);
        melody2B.volume = Mathf.MoveTowards(melody2B.volume, 0f, fadeSpeed * Time.deltaTime);
        }
        else
        {
        melody1A.volume = Mathf.MoveTowards(melody1A.volume, 0f, fadeSpeed * Time.deltaTime);
        melody1B.volume = Mathf.MoveTowards(melody1B.volume, 0f, fadeSpeed * Time.deltaTime);

        melody2A.volume = Mathf.MoveTowards(melody2A.volume, maxVolume, fadeSpeed * Time.deltaTime);
        melody2B.volume = Mathf.MoveTowards(melody2B.volume, maxVolume, fadeSpeed * Time.deltaTime);
        }
        if(swapDrums)
        {
        drumLoop1A.volume = Mathf.MoveTowards(drumLoop1A.volume, maxVolume, fadeSpeed * Time.deltaTime);
        drumLoop1B.volume = Mathf.MoveTowards(drumLoop1B.volume, maxVolume, fadeSpeed * Time.deltaTime);

        drumLoop2A.volume = Mathf.MoveTowards(drumLoop2A.volume, 0f, fadeSpeed * Time.deltaTime);
        drumLoop2B.volume = Mathf.MoveTowards(drumLoop2B.volume, 0f, fadeSpeed * Time.deltaTime);
        }
        else
        {
        drumLoop1A.volume = Mathf.MoveTowards(drumLoop1A.volume, 0f, fadeSpeed * Time.deltaTime);
        drumLoop1B.volume = Mathf.MoveTowards(drumLoop1B.volume, 0f, fadeSpeed * Time.deltaTime);

        drumLoop2A.volume = Mathf.MoveTowards(drumLoop2A.volume,maxVolume, fadeSpeed * Time.deltaTime);
        drumLoop2B.volume = Mathf.MoveTowards(drumLoop2B.volume, maxVolume, fadeSpeed * Time.deltaTime);
        }
    }
    private void PlayMovingMix()
    {
        chordsA.volume = Mathf.MoveTowards(chordsA.volume, 0f, fadeSpeed * Time.deltaTime);
        chordsB.volume = Mathf.MoveTowards(chordsB.volume, 0f, fadeSpeed * Time.deltaTime);
        breakcoreLoop.volume = Mathf.MoveTowards(breakcoreLoop.volume, 0f, fadeSpeed * Time.deltaTime);
        if(swapMelody)
        {
        melody1A.volume = Mathf.MoveTowards(melody1A.volume, maxVolume, fadeSpeed * Time.deltaTime);
        melody1B.volume = Mathf.MoveTowards(melody1B.volume, maxVolume, fadeSpeed * Time.deltaTime);

        melody2A.volume = Mathf.MoveTowards(melody2A.volume, 0f, fadeSpeed * Time.deltaTime);
        melody2B.volume = Mathf.MoveTowards(melody2B.volume, 0f, fadeSpeed * Time.deltaTime);
        }
        else
        {
        melody1A.volume = Mathf.MoveTowards(melody1A.volume, 0f, fadeSpeed * Time.deltaTime);
        melody1B.volume = Mathf.MoveTowards(melody1B.volume, 0f, fadeSpeed * Time.deltaTime);

        melody2A.volume = Mathf.MoveTowards(melody2A.volume, maxVolume, fadeSpeed * Time.deltaTime);
        melody2B.volume = Mathf.MoveTowards(melody2B.volume, maxVolume, fadeSpeed * Time.deltaTime);
        }

        drumLoop1A.volume = Mathf.MoveTowards(drumLoop1A.volume, maxVolume, fadeSpeed * Time.deltaTime);
        drumLoop1B.volume = Mathf.MoveTowards(drumLoop1B.volume, maxVolume, fadeSpeed * Time.deltaTime);

        drumLoop2A.volume = Mathf.MoveTowards(drumLoop2A.volume, maxVolume, fadeSpeed * Time.deltaTime);
        drumLoop2B.volume = Mathf.MoveTowards(drumLoop2B.volume, maxVolume, fadeSpeed * Time.deltaTime);
        
    }
    private void PlayMovingMixInclusive()
    {
        chordsA.volume = Mathf.MoveTowards(chordsA.volume, maxVolume, fadeSpeed * Time.deltaTime);
        chordsB.volume = Mathf.MoveTowards(chordsB.volume, maxVolume, fadeSpeed * Time.deltaTime);
        
        melody1A.volume = Mathf.MoveTowards(melody1A.volume, maxVolume, fadeSpeed * Time.deltaTime);
        melody1B.volume = Mathf.MoveTowards(melody1B.volume, maxVolume, fadeSpeed * Time.deltaTime);

        melody2A.volume = Mathf.MoveTowards(melody2A.volume, maxVolume, fadeSpeed * Time.deltaTime);
        melody2B.volume = Mathf.MoveTowards(melody2B.volume, maxVolume, fadeSpeed * Time.deltaTime);
        
        
        drumLoop1A.volume = Mathf.MoveTowards(drumLoop1A.volume, maxVolume, fadeSpeed * Time.deltaTime);
        drumLoop1B.volume = Mathf.MoveTowards(drumLoop1B.volume, maxVolume, fadeSpeed * Time.deltaTime);

        drumLoop2A.volume = Mathf.MoveTowards(drumLoop2A.volume, maxVolume, fadeSpeed * Time.deltaTime);
        drumLoop2B.volume = Mathf.MoveTowards(drumLoop2B.volume, maxVolume, fadeSpeed * Time.deltaTime);
        
    }
    private void PlayMenuMusic()
    {
        chordsA.volume = Mathf.MoveTowards(chordsA.volume, maxVolume, fadeSpeed * Time.deltaTime);
        chordsB.volume = Mathf.MoveTowards(chordsB.volume, maxVolume, fadeSpeed * Time.deltaTime);
        if(swapMelody)
        {
        melody1A.volume = Mathf.MoveTowards(melody1A.volume, maxVolume, fadeSpeed * Time.deltaTime);
        melody1B.volume = Mathf.MoveTowards(melody1B.volume, maxVolume, fadeSpeed * Time.deltaTime);

        melody2A.volume = Mathf.MoveTowards(melody2A.volume, 0f, fadeSpeed * Time.deltaTime);
        melody2B.volume = Mathf.MoveTowards(melody2B.volume, 0f, fadeSpeed * Time.deltaTime);
        }
        else
        {
        melody1A.volume = Mathf.MoveTowards(melody1A.volume, 0f, fadeSpeed * Time.deltaTime);
        melody1B.volume = Mathf.MoveTowards(melody1B.volume, 0f, fadeSpeed * Time.deltaTime);

        melody2A.volume = Mathf.MoveTowards(melody2A.volume, maxVolume, fadeSpeed * Time.deltaTime);
        melody2B.volume = Mathf.MoveTowards(melody2B.volume, maxVolume, fadeSpeed * Time.deltaTime);
        }
        if(swapDrums)
        {
        drumLoop1A.volume = Mathf.MoveTowards(drumLoop1A.volume, maxVolume, fadeSpeed * Time.deltaTime);
        drumLoop1B.volume = Mathf.MoveTowards(drumLoop1B.volume, maxVolume, fadeSpeed * Time.deltaTime);

        drumLoop2A.volume = Mathf.MoveTowards(drumLoop2A.volume, 0f, fadeSpeed * Time.deltaTime);
        drumLoop2B.volume = Mathf.MoveTowards(drumLoop2B.volume, 0f, fadeSpeed * Time.deltaTime);
        }
        else
        {
        drumLoop1A.volume = Mathf.MoveTowards(drumLoop1A.volume, 0f, fadeSpeed * Time.deltaTime);
        drumLoop1B.volume = Mathf.MoveTowards(drumLoop1B.volume, 0f, fadeSpeed * Time.deltaTime);

        drumLoop2A.volume = Mathf.MoveTowards(drumLoop2A.volume, maxVolume, fadeSpeed * Time.deltaTime);
        drumLoop2B.volume = Mathf.MoveTowards(drumLoop2B.volume, maxVolume, fadeSpeed * Time.deltaTime);
        }
    }

    void Update()
    {
        if(ServiceHubManager.Instance.gameStateManager._currentState != GameStates.Gameplay)
        {
            PlayMenuMusic();
            return;
        }

        if(plr.transform.position.x - deathWall.transform.position.x < 50f )
        {
            breakcoreLoop.volume = 50/ math.clamp(plr.transform.position.x - deathWall.transform.position.x, 1, 50);
        }   

        if(playerMotor.momentum.x > 0.2f)
        {
            PlayMovingMix();
        }
        else
        {
            PlayChillMix();
        }
    }

} 
