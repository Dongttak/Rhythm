using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.UI;


public class SoundController : MonoBehaviour
{
    private Bus musicBus;
    public Slider volumeSlider;
    
    void Start()
    {
        // FMOD에서 노래 이벤트 생성
        musicBus = RuntimeManager.GetBus("bus:/");
        
        // 슬라이더 값이 변경될 때마다 바꾼다아 
        volumeSlider.onValueChanged.AddListener(SetMusicVolume);
    }
    
    // 🔊 볼륨 조절 함수
    private void SetMusicVolume(float volume)
    {
        musicBus.setVolume(volume);
    }
}