using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public Transform[] spawnPoints; // 4개의 스폰 포인트
    public GameObject[] notePrefabs; // 4개의 노트 프리팹
    public float noteSpeed = 5f;

    public void SpawnNote(OsuHitObject hitObject, int lane)
    {
        if (spawnPoints == null || spawnPoints.Length < 4)
        {
            Debug.LogError("SpawnPoints 배열이 설정되지 않았습니다!");
            return;
        }

        if (lane < 0 || lane >= spawnPoints.Length || lane >= notePrefabs.Length)
        {
            Debug.LogError($"잘못된 Lane 값: {lane}");
            return;
        }

        Transform spawnPoint = spawnPoints[lane];
        GameObject notePrefab = notePrefabs[lane];

        GameObject note = Instantiate(notePrefab, spawnPoint.position, Quaternion.identity);
        NoteController controller = note.GetComponent<NoteController>();

        if (controller != null)
        {
            controller.speed = noteSpeed; //노트 속도 설정
        }
        else
        {
            Debug.LogError("NoteController가 프리팹에 없습니다!");
        }
    }
}