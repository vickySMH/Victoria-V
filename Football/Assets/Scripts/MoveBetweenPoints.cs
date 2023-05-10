using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 1.0f;

    private float lerpValue;

    private void Update()
    {
        // Calculate the new lerp value
        lerpValue = Mathf.PingPong(Time.time * speed, 1.0f);

        // Update the object position based on the lerp value
        transform.position = Vector3.Lerp(pointA.position, pointB.position, lerpValue);
    }
}