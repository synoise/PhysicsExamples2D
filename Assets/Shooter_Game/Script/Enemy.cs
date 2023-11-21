using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private bool isChasing;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        isChasing = true;
        StartCoroutine(Chase());
    }

    private IEnumerator Chase()
    {
        while (isChasing)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            RotateToTarget(target);


            yield return null;
        }
    }


    private void RotateToTarget(Transform target)
    {
        Vector3 difference = target.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    }
    private void OnHit()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D zombie " + collision.collider.tag);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            OnHit();
        }
    }
}
