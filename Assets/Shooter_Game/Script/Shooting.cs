using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] float bulletForce = 20f;

    [SerializeField] Animator playerAnimator;

    PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        playerMovement.SetMove(false);

        Look();

        playerAnimator.SetTrigger("Shoot");     // Bullet instantiated using animation events

        yield return new WaitForSeconds(0.5f);

        playerMovement.SetMove(true);
    }

    public void InstantiateBullet()
    {
        GameObject _bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody _bulletRb = _bullet.GetComponent<Rigidbody>();

        _bulletRb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }

    private void Look()
    {
        // Raycast from the camera to the ground to get the intersection point
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Get the intersection point as the target position
            Vector3 targetPosition = hit.point;

            // Calculate direction vector
            Vector3 direction = targetPosition - transform.position;
            direction.y = 0; // Ensure the direction is in the horizontal plane.

            // Rotate the character
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
        }
    }
}
