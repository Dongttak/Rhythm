using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.UIElements;

public class SoundController : MonoBehaviour
{
    private EventInstance musicEvent;
    
    void Start()
    {
        // FMOD에서 노래 이벤트 생성
        musicEvent = RuntimeManager.CreateInstance("event:/Music_Full");
        musicEvent.start();
        
        
        
    }

    void Update()
    {
        Slider slider = GetComponent<Slider>();
        SetMusicVolume(slider.value);
    }

    // 🔊 볼륨 조절 함수
    private void SetMusicVolume(float volume)
    {
        musicEvent.setVolume(volume);
    }
}