using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float shootForce = 10f;
    public float shootRate = 0.2f;

    private float shootTimer = 0f;

    private void Update()
    {
        shootTimer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && shootTimer >= shootRate)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    private void Shoot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

        if (projectileRb != null)
        {
            Vector2 shootDirection = (mousePosition - projectileSpawnPoint.position).normalized;
            projectileRb.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogError("The projectile prefab does not have a Rigidbody2D component!");
        }
    }
}
