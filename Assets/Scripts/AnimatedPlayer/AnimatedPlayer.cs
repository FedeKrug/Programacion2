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
    [SerializeField] private Animator _anim;
    [SerializeField] private string _xAxisName, _zAxisName;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
        
        if (_anim== null)
        {
            _anim = GetComponentInChildren<Animator>();
        }


    }
    private void Update()
    {
        _xAxis = Input.GetAxisRaw("Horizontal");
        _zAxis = Input.GetAxisRaw("Vertical");

        _anim.SetFloat(_xAxisName, _xAxis);
        _anim.SetFloat(_zAxisName, _zAxis);
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
        var dir = (transform.right * xAxis + transform.forward * zAxis * _movementSpeed *Time.fixedDeltaTime).normalized;
        _rb.velocity = dir;
    }
}
