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

    public float view_angle = 25; // In degrees

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
            Vector3 axis = Vector3.Cross(bullet_dir, Vector3.up);
            Vector3 spread_dir = Quaternion.AngleAxis(Random.Range(0,spread), axis) * bullet_dir;
            Vector3 final_dir = Quaternion.AngleAxis(Random.Range(0,360), bullet_dir) * spread_dir;

            // Pass the bullet direction to the new bullet we created
            new_bullet.GetComponent<Bullet>().SetVelocity(final_dir); 
        }
        
    }

    private void OnDrawGizmos()
    {
        // Draw a line to represent bullet direction
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + bullet_dir * 2);

        #region Bullet Spread Cone

        /*// Draw the up vector
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

        // Show cone of possible directions for bullet to travel in
        Gizmos.color = Color.magenta;
        Vector3 final_dir;
        for (int i = 1; i <= 15; i++)
        {
            final_dir = Quaternion.AngleAxis(22.5f * i, bullet_dir) * spread_dir;
            Gizmos.DrawLine(transform.position, transform.position + final_dir * 2);
        }*/

        #endregion

        #region Vision Cone

        Gizmos.color = Color.beige;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2);

        float half_angle = view_angle / 2;

        Vector3 right = Quaternion.AngleAxis(half_angle, Vector3.up) * transform.forward;
        Vector3 left = Quaternion.AngleAxis(-half_angle, Vector3.up) * transform.forward;

        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, transform.position + right * 10);
        Gizmos.DrawLine(transform.position, transform.position + left * 10);


        #endregion
    }
}
