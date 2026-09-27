
using Unity.Mathematics;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    [SerializeField] AudioClip jump;
    private AudioSource oneShotAudioSource;
    [SerializeField] AudioSource onWall;
    [SerializeField] AudioSource WindHowl;

    private GameObject plr;
    private PlayerInputs inputs;
    private PlayerMotor motor;
    void Start()
    {
        plr = ServiceHubManager.Instance.player;
        motor = plr.GetComponent<PlayerMotor>(); 
        inputs = plr.GetComponent<PlayerInputs>();
        oneShotAudioSource = transform.GetComponent<AudioSource>();
        EventBus.RequestEvent("Jumped", true).ping += playJump;
    }
    void OnDestroy()
    {
        EventBus.RequestEvent("Jumped", true).ping -= playJump;
    }
    void OnEnable()
    {
        oneShotAudioSource = transform.GetComponent<AudioSource>();
    }
    void playJump()
    {
        oneShotAudioSource.PlayOneShot(jump);
    }

    void Update()
    {
        if(ServiceHubManager.Instance.gameStateManager._currentState != GameStates.Gameplay)
        {
            onWall.volume = math.lerp(onWall.volume, 0, 0.2f);
            math.lerp( WindHowl.volume, 0, 0.2f);
            return;
        }
        
        if(inputs.onWall && motor.momentum.y > 0.01f) onWall.volume = math.lerp(onWall.volume, 1, 0.2f);
        else onWall.volume = math.lerp(onWall.volume, 0, 0.2f);
        WindHowl.volume = math.lerp( WindHowl.volume, motor.momentum.magnitude * 0.5f, 0.2f);
    }
}

