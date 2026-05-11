using UnityEngine;

public class MovingWall : MonoBehaviour
{
 [SerializeField] private Vector3 moveOffset = new Vector3(0f, 3f, 0f);
 [SerializeField] private float speed = 1.5f;

     private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1.5f);
        transform.position = Vector3.Lerp(startPos, startPos + moveOffset, t);
    }
}
