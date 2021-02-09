using UnityEngine;

public class KubeController : MonoBehaviour
{
    Rigidbody rb;
    bool moveForward = false;
    bool isMoving = false;
    public float forwardForce = 800f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isMoving) moveForward = true;
        }
    }

    void FixedUpdate()
    {
        // We'll add velocity change force only once on keypress
        if (moveForward)
        {
            // Add force to Kube's rigidbody
            var direction = Vector3.forward;
            var force = forwardForce;
            var mode = ForceMode.VelocityChange;

            // Apply force to Kube
            applyForce(force, direction, mode);

            // Clear forces
            isMoving = true;
            moveForward = false;
        }
    }

    void applyForce(float force, Vector3 direction, ForceMode mode)
    {
        var velocity = direction * rb.mass * force * Time.fixedDeltaTime;
        rb.AddForce(velocity, mode);
    }

    void OnCollisionEnter(Collision other)
    {

    }

}
