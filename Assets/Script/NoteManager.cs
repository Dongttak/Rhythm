using UnityEngine;
using System.Collections.Generic;
public class NoteManager : MonoBehaviour
{
    public float timingOffset = 0f;
    public NoteSpawner noteSpawner; //NoteSpawner 추가
    public string osuFilePath;
    public List<OsuHitObject> hitObjects;
    private float startTime;
    private int nextNoteIndex = 0;

    void Start()
    {
        
        hitObjects = OsuParser.ParseOsuFile(osuFilePath);

        if (hitObjects == null || hitObjects.Count == 0)
        {
            Debug.LogError("OsuParser에서 hitObjects를 가져오지 못했습니다!");
            return;
        }

        startTime = SoundController.instance.GetMusicStartTime();
    }

    void Update()
    {
        if (nextNoteIndex >= hitObjects.Count) return;

        float currentTime = (Time.time - startTime) * 1000f; // 경과 시간(ms 단위)
        
        Debug.Log($"음악 진행 시간: {currentTime}ms, 다음 노트 시간: {hitObjects[nextNoteIndex].time}ms");
        
        while (nextNoteIndex < hitObjects.Count && hitObjects[nextNoteIndex].time <= currentTime)
        {
            OsuHitObject hitObject = hitObjects[nextNoteIndex];
            int lane = ConvertToLane(hitObject.x);
            noteSpawner.SpawnNote(hitObject, lane);
            nextNoteIndex++;
        }
    }

    int ConvertToLane(float x)
    {
        return Mathf.Clamp((int)(x / 128), 0, 3);
    }
}