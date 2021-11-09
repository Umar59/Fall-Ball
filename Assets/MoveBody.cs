using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBody : MonoBehaviour
{

    [SerializeField] private float speed = 30f;
    private Rigidbody cube;
    private float direction;
    private void Awake()
    {
        cube = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        cube.transform.Rotate(0f, direction * speed * Time.fixedDeltaTime, 0f);
    }

    private void Move(float direction)
    {
        this.direction = direction;
    }

    void OnEnable()
    {
        TouchInput.OnMove += Move;
    }
    void OnDisable()
    {
        TouchInput.OnMove -= Move;
    }
}
