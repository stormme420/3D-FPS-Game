using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Camera playerCamera;
    public float range = 100f;
    public int damage = 25;
    public float fireRate = 0.12f;
    public LayerMask hitMask;

    private float nextFireTime;

    private void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range, hitMask))
        {
            EnemyAI enemy = hit.collider.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log("Hit enemy: " + enemy.gameObject.name);
            }
        }
    }
}
