using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    private Rigidbody rb;
    private float movementlnputValue;
    private float turnlnputValue;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        TankMove();
        TankTurn();
    }

    void TankMove()
    {
        movementlnputValue = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * movementlnputValue * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    void TankTurn()
    {
        turnlnputValue=Input.GetAxis("Horizontal");
        float turn = turnlnputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotaition = Quaternion.Euler(0,turn,0);
        rb.MoveRotation(rb.rotation * turnRotaition);
    }
}
