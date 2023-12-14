using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventTriggerer : MonoBehaviour
{
    PlayerMovement playerMovement;
    Shooting shooting;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        shooting = FindObjectOfType<Shooting>();
    }

    public void SetMovement(bool status)
    {
        playerMovement.SetMove(status);
    }

    public void BulletOnShoot()
    {
        shooting.InstantiateBullet();
    }
}
