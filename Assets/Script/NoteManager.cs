using UnityEngine;
using System.Collections.Generic;
public class NoteManager : MonoBehaviour
{
    public NoteSpawner noteSpawner; 
    public List<OsuHitObject> hitObjects; // osu 파일에서 파싱된 데이터
    private int nextNoteIndex = 0;
    private float startTime;

    void Start()
    {
        if (hitObjects == null || hitObjects.Count == 0)
        {
            Debug.LogError("hitObjects가 null이거나 비어 있습니다!");
            return;
        }
    
        startTime = Time.time;
    }

    void Update()
    {
        if (nextNoteIndex >= hitObjects.Count) return; // 모든 노트 생성 완료

        float currentTime = (Time.time - startTime) * 1000f; // 경과 시간(ms 단위)

        while (nextNoteIndex < hitObjects.Count && hitObjects[nextNoteIndex].time <= currentTime)
        {
            OsuHitObject hitObject = hitObjects[nextNoteIndex];
            int lane = ConvertToLane(hitObject.x);
            noteSpawner.SpawnNote(hitObject, lane);
            nextNoteIndex++; // 다음 노트로 이동
        }
    }

    int ConvertToLane(float x)
    {
        return Mathf.Clamp((int)(x / 128), 0, 3);
    }
}