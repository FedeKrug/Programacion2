using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AnimatedPlayer : MonoBehaviour
{
    [SerializeField] private float _xAxis, _zAxis;
    private Rigidbody _rb;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private int _atkButton =0;



    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
    private void Update()
    {
        _xAxis = Input.GetAxis("Horizontal");
        _zAxis = Input.GetAxis("Vertical");
    }


    private void FixedUpdate()
    {
        if (_xAxis !=0|| _zAxis !=0)
        {
            Movement(_xAxis,_zAxis);
        }
    }

    private void Movement(float xAxis, float zAxis)
    {
        var dir = (transform.right * xAxis + transform.forward * zAxis * _movementSpeed *Time.fixedDeltaTime);
        _rb.velocity = dir;
    }
}
