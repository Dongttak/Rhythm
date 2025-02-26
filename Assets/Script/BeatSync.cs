using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class BeatSync : MonoBehaviour
{
    public StudioEventEmitter emitter;
    private EventInstance eventInstance;
    private float songLength;
    
    void Start()
    {
        eventInstance = emitter.EventInstance;
        eventInstance.getDescription(out EventDescription eventDesc);
        eventDesc.getLength(out int length);
        songLength = length / 1000f; // 밀리초를 초 단위로 변환
    }
}