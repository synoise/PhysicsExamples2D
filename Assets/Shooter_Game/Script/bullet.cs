using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asesino_Zombie
{
    public class Bullet : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Invoke(nameof(DestroyBullet), 2f);
        }


        void DestroyBullet()
        {
            Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
        }
    }
}