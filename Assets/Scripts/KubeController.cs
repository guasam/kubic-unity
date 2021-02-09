using UnityEngine;

public class KubeController : MonoBehaviour
{
    Rigidbody rb;
    bool moving = false;
    float forwardForce = 800f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !moving)
        {
            moving = true;
        }
    }

    void FixedUpdate()
    {
        // We'll add velocity change force only once on keypress
        if (moving)
        {
            // Add force to Kube's rigidbody
            var direction = Vector3.forward;
            var velocity = direction * rb.mass * forwardForce * Time.fixedDeltaTime;
            rb.AddForce(velocity, ForceMode.VelocityChange);

            // Set moved status to false
            moving = false;
        }
    }
}
