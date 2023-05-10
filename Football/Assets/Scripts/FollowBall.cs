using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public Transform ball;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - ball.position;
    }

    private void LateUpdate()
    {
        transform.position = ball.position + offset;
    }
}