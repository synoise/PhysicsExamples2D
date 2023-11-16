using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotation;

    private Rigidbody2D rigid;
    private Vector2 movementInput;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotationInDirection();
    }

    private void SetPlayerVelocity()
    {
        rigid.velocity = movementInput * speed;
    }

    private void RotationInDirection()
    {
        if (movementInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, movementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed);

            rigid.MoveRotation(rotation);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();

    }
}
