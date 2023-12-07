using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    [SerializeField] float initHealth;
    float health;

    [SerializeField] Slider healthSlider;

    private bool canBeHit = true;

    private void OnEnable()
    {
        EventsManager.OnPlayerHitE += ReduceHealth;
    }

    private void OnDisable()
    {
        EventsManager.OnPlayerHitE -= ReduceHealth;
    }

    private void Start()
    {
        health = initHealth;
        healthSlider.value = health;
    }

    public void ReduceHealth()
    {
        health--;
        healthSlider.value = health;

        if (health <= 0f)
        {
            PlayerDied();
        }
    }

    public void ResetHealth()
    {
        health = initHealth;
        healthSlider.value = health;
    }

    public void PlayerDied()
    {
        Debug.Log("You Died");
        EventsManager.OnPlayerDied();
    }

    private IEnumerator OnPlayerHit()
    {
        canBeHit = false;
        ReduceHealth();

        yield return new WaitForSeconds(1f);

        canBeHit = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (canBeHit)
                StartCoroutine(OnPlayerHit());
        }
    }
}
