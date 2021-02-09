using UnityEngine;

public class KubeController : MonoBehaviour
{
    Rigidbody rb;

    public float maxSpeed = 10f;
    public float forwardForce = 2f;
    public float sidewayForce = 100f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Move forward
        rb.AddForce(0, 0, forwardForce, ForceMode.VelocityChange);

        // Move sideways
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-sidewayForce, 0, 0, ForceMode.Acceleration);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(sidewayForce, 0, 0, ForceMode.Acceleration);
        }

        // Clamp speed to maximum speed
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed - forwardForce);
    }
}
