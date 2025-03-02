using UnityEngine;

public class NoteController : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime; //일정한 속도로 이동

        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }
}
