using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] float bulletForce = 20f;

    [SerializeField] Animator playerAnimator;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Look();

        GameObject _bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody _bulletRb = _bullet.GetComponent<Rigidbody>();

        _bulletRb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);

        playerAnimator.SetTrigger("Shoot");
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
