using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [Header("Weapon Settings")]
    [SerializeField] public GameObject projectilePrefab;   // Assign your bullet prefab in the Inspector
    public Transform firePoint;           // An empty child GameObject indicating where the bullet should spawn
    public float projectileSpeed = 10f;
     public float firePointDistance = 3f;
     public Vector2 firePointOffset = new Vector2(0f, 0.2f); // ↑ move it 0.2 units above

    void Update()
    {
        UpdateFirePointPosition();
        // Check if the left mouse button (mouse button 0) is pressed.
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void UpdateFirePointPosition()
{
    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    mousePos.z = 0f;

    Vector3 direction = (mousePos - transform.position).normalized;

    // Base position on circle around player
    Vector3 circlePos = transform.position + direction * firePointDistance;

    // Add your vertical offset (or any Vector2 offset)
    firePoint.position = circlePos + (Vector3)firePointOffset;
}
    void Shoot()
    {
        // Instantiate the projectile at the fire point's position and rotation.
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        
        // Get the Rigidbody2D component on the projectile.
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Convert the mouse position from screen space to world space.
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Adjust the z-coordinate to match the fire point.
        mousePos.z = firePoint.position.z;

        // Calculate the direction from the fire point to the mouse position.
        Vector2 direction = (mousePos - firePoint.position).normalized;
        
        // Set the projectile's velocity so it travels toward the mouse pointer.
        rb.linearVelocity = direction * projectileSpeed;
    }
}
