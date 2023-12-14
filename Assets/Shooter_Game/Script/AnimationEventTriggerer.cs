using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventTriggerer : MonoBehaviour
{
    PlayerMovement playerMovement;
    Enemy enemy;
    Shooting shooting;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        shooting = FindObjectOfType<Shooting>();
        enemy = FindObjectOfType<Enemy>();
    }

    public void EnableEnemyMovement()
    {
        enemy.SetChaseState(true);
    }

    public void DisableEnemyMovement()
    {
        enemy.SetChaseState(false);
    }

    public void BulletOnShoot()
    {
        shooting.InstantiateBullet();
    }
}
