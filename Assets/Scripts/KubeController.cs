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

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        scoreText.text = score.ToString();
    }

    void FixedUpdate()
    {
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

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Hurdle"))
        {
            scoreText.text = "Ouch...";
            isAlive = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            scoreText.text = "Finished";
            isAlive = false;
        }
    }
}
