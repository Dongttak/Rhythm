using FMODUnity;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public StudioEventEmitter eventEmitter;

    void Start()
    {
        eventEmitter.Play();  // 이벤트 실행
    }
}