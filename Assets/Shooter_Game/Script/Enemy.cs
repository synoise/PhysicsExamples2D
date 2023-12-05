using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private bool isChasing;

    private Transform target;
    
    [SerializeField] private TMP_Text score;
    
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
    private void OnHit()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            OnHit();
            //score.text = (int.Parse(score.text) + 1).ToString();
        }
    }
}
