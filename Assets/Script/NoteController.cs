using UnityEngine;

public class NoteController : MonoBehaviour
{
    public float speed = 5f;  // 노트가 내려오는 속도
    private Vector3 targetPosition;

    public void SetTarget(float x, float y, float speed)
    {
        this.speed = speed;
        targetPosition = new Vector3(x, y, 0);  // 타겟 포지션 설정 (필요하면 조정 가능)
    }

    void Update()
    {
        // 노트가 아래 방향으로 이동하도록 설정
        transform.position += Vector3.down * speed * Time.deltaTime;

        // 특정 지점(Y값) 이하로 내려가면 삭제
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}