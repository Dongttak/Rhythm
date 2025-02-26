using UnityEngine;

public class NoteController : MonoBehaviour
{
    public float speed = 5f; // 노트 이동 속도

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}