using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace Asesino_Zombie
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private GameObject sparkVFXGameObject;

        // Start is called before the first frame update
        void Start()
        {
            Invoke(nameof(DestroyBullet), 2f);
        }


        void DestroyBullet()
        {
            Destroy(gameObject);
        }

        private Vector3 GetBulletPosition()
        {
            return this.transform.position;
        }



        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Vector3 bulletLastPosition = GetBulletPosition();
                Instantiate(sparkVFXGameObject, bulletLastPosition, collision.transform.rotation);

                Destroy(gameObject);
            }
        }
    }
}