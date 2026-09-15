using UnityEngine;

public class Turret : MonoBehaviour
{
    // Shooting
    public GameObject target;
    public GameObject bullet;
    public float rate_of_fire = 0.2f;
    private float shoot_timer = 0;
    private Vector3 bullet_dir = Vector3.zero;
    public float spread = 5f; // In degrees

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Remove
        bullet_dir = (target.transform.position - transform.position).normalized;
        return;

        // If there's time left
        if (shoot_timer > 0)
            shoot_timer -= Time.deltaTime; // Subtract delta time from it, allow timer to go down
        else
        {
            // Spawn Bullets
            shoot_timer = rate_of_fire;

            // Create new Bullet
            GameObject new_bullet = Instantiate(bullet);

            // Move bullet to turret's position
            new_bullet.transform.position = transform.position;

            // Get direction the bullet will travel in
            bullet_dir = (target.transform.position - transform.position).normalized;

            // Pass the bullet direction to the new bullet we created
            new_bullet.GetComponent<Bullet>().SetVelocity(bullet_dir);

        }
        
    }

    private void OnDrawGizmos()
    {
        // Draw a line to represent bullet direction
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + bullet_dir * 2);

        // Draw the up vector
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * 2);

        // Draw axis of rotation
        Gizmos.color = Color.cyan;
        Vector3 axis = Vector3.Cross(bullet_dir, Vector3.up);
        Gizmos.DrawLine(transform.position, transform.position + axis * 2);

        // Rotate bullet_dir along axis
        Gizmos.color = Color.yellow;
        Vector3 spread_dir = Quaternion.AngleAxis(spread, axis) * bullet_dir;
        Gizmos.DrawLine(transform.position, transform.position + spread_dir * 2);
    }
}
