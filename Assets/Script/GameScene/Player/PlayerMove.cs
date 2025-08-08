using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject ValueManager;
    Value value;

    public float max_Speed = 5;
    float Speed;
    float moveX;
    float moveY;
    Rigidbody2D rb;
    void Start()
    {
        value = ValueManager.GetComponent<Value>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal"); // A, D
        moveY = Input.GetAxisRaw("Vertical");   // W, S
        Vector3 moveDirection = new Vector3(moveX, moveY, 0).normalized;

        Vector3 move_point = (moveDirection * Time.deltaTime * Speed) + transform.position;
        if (math.abs(move_point.x) > value.x_boundary)
        {
            move_point.x = value.x_boundary * Math.Sign(move_point.x);
        }
        if (math.abs(move_point.y) > value.y_boundary)
        {
            move_point.y = value.y_boundary * Math.Sign(move_point.y);
        }
        transform.position = move_point;
    }
}