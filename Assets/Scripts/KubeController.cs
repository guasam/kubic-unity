using UnityEngine;
using UnityEngine.UI;

public class KubeController : MonoBehaviour
{
    Rigidbody rb;
    int score = 0;
    bool isAlive = true;

    public float maxSpeed = 10f;
    public float forwardForce = 2f;
    public float sidewayForce = 100f;

    public Text scoreText;

    /// <summary>
    /// Called when object gets instantiated
    /// </summary>
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        scoreText.text = score.ToString();
    }

    /// <summary>
    /// Called every physics frame
    /// </summary>
    void FixedUpdate()
    {
        // Kube is alive or has been sacrificed
        if (!isAlive)
        {
            rb.drag = 2f;
            return;
        }

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

        // Respawn if fallen
        if (rb.position.y < -0.2)
        {
            scoreText.text = "Ooops...";
            isAlive = false;
            return;
        }

        // Clamp speed to maximum speed
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed - forwardForce);

        // Increase score
        score++;
        scoreText.text = score.ToString();
    }

    /// <summary>
    /// Handle Collision
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionEnter(Collision other)
    {
        // Hitting head with Hurdles
        if (other.collider.CompareTag("Hurdle"))
        {
            scoreText.text = "Ouch...";
            isAlive = false;
        }
    }

    /// <summary>
    /// Handle Trigger Collision
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        // Reached the finish line
        if (other.CompareTag("Finish"))
        {
            scoreText.text = "Finished";
            isAlive = false;
        }
    }
}
