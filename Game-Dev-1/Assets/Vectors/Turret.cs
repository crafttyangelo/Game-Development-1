using UnityEngine;

public class Turret : MonoBehaviour
{
    // Shooting
    public GameObject target;
    public GameObject bullet;
    public float rate_of_fire = 0.2f;
    private float shoot_timer = 0;

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
            Vector3 bullet_dir = (target.transform.position - transform.position).normalized;

            // Pass the bullet direction to the new bullet we created
            new_bullet.GetComponent<Bullet>().SetVelocity(bullet_dir);

        }
        
    }
}
