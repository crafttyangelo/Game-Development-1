using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Components
    private Rigidbody rb;

    // Movement
    public float speed = 16f;
    private Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get component of bullet
        rb = GetComponent<Rigidbody>();
        
        // Destroy after 5 seconds, so there aren't excessive game objects
        Destroy(gameObject,5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move Bullet
        rb.MovePosition(rb.position + (velocity * Time.fixedDeltaTime));
    }
    public void SetVelocity(Vector3 direction)
    {
        // Contruct velocity  vector
        velocity = direction * speed;

    }
}
