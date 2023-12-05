using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    
    private bool isChasing;
    private int health = 3;

    private Transform target;
    [SerializeField] Animator animator;
    
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
        float rotationY = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg ;
        transform.rotation = Quaternion.Euler(0.0f, rotationY, 0.0f);
    }
    private IEnumerator OnHit()
    {
        health--;
        animator.SetTrigger("Hit");
        isChasing = false;

        yield return new WaitForSeconds(0.2f);

        if (health <= 0)
        {
            EventsManager.OnEnemyDied();
            Destroy(gameObject);
        }

        isChasing = true;
        StartCoroutine(Chase());

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(OnHit());
            //score.text = (int.Parse(score.text) + 1).ToString();
        }
    }
}
