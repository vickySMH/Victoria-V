using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    [Tooltip("The character controller to move")]
    public CharacterController characterController;


    [Tooltip("The transformer to rotate when facing direction of travel")]
    public Transform transformer;


    [Header("Move properties")]
    public float moveMaxPerSecond = 24;

    public float moveTimeToMax = .26f;
    public float moveTimeToZero = .2f;
    public float moveReverseMomentum = 2.2f;

    public float slerpSpeed = .018f;

    public Vector3 movement = Vector3.zero;

    private float MoveVelocityGain
    {
        get => moveMaxPerSecond / moveTimeToMax;
    }

    public float MoveVelocityLoss
    {
        get => moveMaxPerSecond / moveTimeToZero;
    }

    public float respawnTime = 2;
    private Vector3 startPoint;
    private Quaternion startRotation;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = characterController.gameObject.transform.position;
        startRotation = transformer.rotation;
        _audioSource = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // Sorting the Z dimension first..
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (movement.z >= 0)
            {
                // Forwards
                movement.z += MoveVelocityGain * Time.deltaTime;
                movement.z = Mathf.Min(moveMaxPerSecond, movement.z);
            }
            else
            {
                // Reverse forwards
                movement.z += MoveVelocityGain * moveReverseMomentum * Time.deltaTime;
                //_movement.z = Mathf.Min(0, _movement.z);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (movement.z <= 0)
            {
                // Backwards
                movement.z -= MoveVelocityGain * Time.deltaTime;
                movement.z = Mathf.Max(-moveMaxPerSecond, movement.z);
            }
            else
            {
                // Break backwards
                movement.z -= MoveVelocityGain * moveReverseMomentum * Time.deltaTime;
                //_movement.z = Mathf.Max(0, _movement.z);
            }
        }
        else
        {
            // Slow down 
            if (movement.z > 0)
            {
                // From forwards
                movement.z -= MoveVelocityLoss * Time.deltaTime;
                movement.z = Mathf.Max(0, movement.z);
            }
            else if (movement.z < 0)
            {
                // From backwards
                movement.z += MoveVelocityLoss * Time.deltaTime;
                movement.z = Mathf.Min(0, movement.z);
            }

        }


        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (movement.x >= 0)
            {
                // Right
                movement.x += MoveVelocityGain * Time.deltaTime;
                movement.x = Mathf.Min(moveMaxPerSecond, movement.x);
            }
            else
            {
                // Reverse right
                movement.x += MoveVelocityGain * moveReverseMomentum * Time.deltaTime;
                //_movement.x = Mathf.Min(0, _movement.x);
            }

        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (movement.x <= 0)
            {
                // Left
                movement.x -= MoveVelocityGain * Time.deltaTime;
                movement.x = Mathf.Max(-moveMaxPerSecond, movement.x);
            }
            else
            {
                // Break left
                movement.x -= MoveVelocityGain * moveReverseMomentum * Time.deltaTime;
                //_movement.x = Mathf.Max(0, _movement.x);
            }
        }
        else
        {
            // Slow down 
            if (movement.x > 0)
            {
                // From right
                movement.x -= MoveVelocityLoss * Time.deltaTime;
                movement.x = Mathf.Max(0, movement.x);
            }
            else if (movement.x < 0)
            {
                // From left
                movement.x += MoveVelocityLoss * Time.deltaTime;
                movement.x = Mathf.Min(0, movement.x);
            }

        }

        if (movement.z != 0 || movement.x != 0)
        {
            characterController.Move(movement * Time.deltaTime);

            var toLookRotation = Quaternion.LookRotation(movement);
            //transformer.rotation = toLookRotation;
            transformer.rotation = Quaternion.Slerp(transformer.rotation, toLookRotation, slerpSpeed);

        }
    }

    public Vector3 Position
    {
        get => characterController.gameObject.transform.position;
    }

    public float Speed
    {
        get => Mathf.Abs(movement.x) + Mathf.Abs(movement.z) / 2;
    }
}
