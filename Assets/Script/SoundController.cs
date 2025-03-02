using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.UI;


public class SoundController : MonoBehaviour
{
    public static SoundController instance;
    private float musicStartTime;
    private Bus musicBus;
    public Slider volumeSlider;
    
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    
    void Start()
    {
        // FMOD에서 노래 이벤트 생성
        musicBus = RuntimeManager.GetBus("bus:/");
        
        // 슬라이더 값이 변경될 때마다 바꾼다아 
        volumeSlider.onValueChanged.AddListener(SetMusicVolume);
        
        musicStartTime = Time.time;
    }
    
    // 🔊 볼륨 조절 함수
    private void SetMusicVolume(float volume)
    {
        musicBus.setVolume(volume);
    }
    public float GetMusicStartTime()
    {
        return musicStartTime;
    }
}