using UnityEngine;

public class KubeController : MonoBehaviour
{
    Rigidbody rb;
    bool moveForward = false;
    bool jump = false;
    bool isMoving = false;
    float forwardForce = 800f;
    float jumpForce = 400f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isMoving) moveForward = true;
            else jump = true;
        }
    }

    void FixedUpdate()
    {
        // We'll add velocity change force only once on keypress
        if (moveForward || jump)
        {
            // Add force to Kube's rigidbody
            var direction = jump ? Vector3.up : Vector3.forward;
            var force = jump ? jumpForce : forwardForce;

            // Apply force to Kube
            applyForce(force, direction);

            // Clear forces
            isMoving = true;
            moveForward = false;
            jump = false;
        }
    }

    void applyForce(float force, Vector3 direction)
    {
        var velocity = direction * rb.mass * force * Time.fixedDeltaTime;
        rb.AddForce(velocity, ForceMode.VelocityChange);
    }
}
