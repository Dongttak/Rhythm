using UnityEngine;
using System.Collections;

public class OsuNoteSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    public OsuParser osuParser;
    public Transform[] lanes; // 4키 게임이라면 4개의 라인 필요

    private OsuMapData mapData;

    void Start()
    {
        mapData = osuParser.mapData;
        StartCoroutine(SpawnNotes());
    }

    IEnumerator SpawnNotes()
    {
        foreach (OsuHitObject note in mapData.hitObjects)
        {
            yield return new WaitForSeconds(note.time / 1000f); // ms → 초 변환
            SpawnNote(note);
        }
    }

    void SpawnNote(OsuHitObject noteData)
    {
        Transform lane = lanes[noteData.x / 128]; // x 좌표를 4개 라인으로 변환
        Instantiate(notePrefab, lane.position, Quaternion.identity);
    }
}