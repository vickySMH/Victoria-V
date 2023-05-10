using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public ResetLevel reset;
    public Rigidbody body;
    public float spinFactor = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player is not null)
            {
                var deltaPosition = body.transform.position - player.Position;

                deltaPosition.y = 0;

                var forward = deltaPosition.normalized;

                body.AddForce(forward * player.Speed, ForceMode.Impulse);

                // Calculate the axis of rotation (perpendicular to the direction of force)
                Vector3 spinAxis = Vector3.Cross(forward, Vector3.up);

                // Apply torque to the Rigidbody to make it spin
                body.AddTorque(-spinAxis * player.Speed * spinFactor, ForceMode.Impulse);
            }
        }

        if (other.gameObject.tag == "Fail")
        {
            reset.ResetFail();
        }

        if (other.gameObject.tag == "Goal")
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt($"Level{sceneIndex}", 1);
            PlayerPrefs.Save();

            reset.ResetGoal();
        }
    }

    public void ResetTorqueAndVelocity()
    {
        // Set velocity to zero to reset the force
        body.velocity = Vector3.zero;

        // Set angular velocity to zero to reset the torque
        body.angularVelocity = Vector3.zero;
    }
}
