using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    
    public Transform[] spawnPoints; // 4개의 스폰 포인트를 저장할 배열
    public GameObject[] notePrefabs;
    public float noteSpeed = 5f;

    public void SpawnNote(OsuHitObject hitObject, int lane)
    {
        if (spawnPoints == null || spawnPoints.Length < 4)
        {
            Debug.LogError("SpawnPoints 배열이 설정되지 않았습니다!");
            return;
        }

        if (lane < 0 || lane >= spawnPoints.Length)
        {
            Debug.LogError($"잘못된 Lane 값: {lane}");
            return;
        }

        Transform spawnPoint = spawnPoints[lane]; // 해당 Lane의 스폰 위치 가져오기
        GameObject notePrefab = notePrefabs[lane]; //prefab 여러개 작성하기
        
        GameObject note = Instantiate(notePrefab, spawnPoint.position, Quaternion.identity);
        NoteController controller = note.GetComponent<NoteController>();

        if (controller != null)
        {
            controller.SetTarget(hitObject.x, hitObject.y, noteSpeed);
        }
        else
        {
            Debug.LogError("NoteController가 프리팹에 없습니다!");
        }
    }
}