using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FirstPersonPlayer : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float _movementSpeed = 5f;
    [Range(1f, 2000f)] [SerializeField] private float _mouseSensitivity = 100f;
    [Header("Components")]
    [SerializeField] private Transform _head;

    private Rigidbody _rb;
    private FirstPersonCamera _cam;
    private float _xAxis, _zAxis, _inputMouseX, _inputMouseY, _mouseX;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _rb = GetComponent<Rigidbody>();

        _cam = Camera.main.GetComponent<FirstPersonCamera>();
        _cam.SetHead(_head);
    }

    private void Update()
    {
        _xAxis = Input.GetAxis("Horizontal");
        _zAxis = Input.GetAxis("Vertical");

        _inputMouseX = Input.GetAxisRaw("Mouse X");
        _inputMouseY = Input.GetAxisRaw("Mouse Y");

        if(_inputMouseX != 0 || _inputMouseY != 0)
        {
            Rotation(_inputMouseX, _inputMouseY);
        }
    }

    private void FixedUpdate()
    {
        if(_xAxis != 0 || _zAxis != 0)
        {
            Movement(_xAxis, _zAxis);
        }
    }

    private void Movement(float xAxis, float zAxis)
    {
        Vector3 dir = (transform.right * xAxis + transform.forward * zAxis).normalized;

        _rb.MovePosition(transform.position += dir * _movementSpeed * Time.fixedDeltaTime);
    }

    private void Rotation(float xAxis, float yAxis)
    {
        _mouseX += xAxis * _mouseSensitivity * Time.deltaTime;

        if(_mouseX >= 360f || _mouseX <= -360f)
        {
            _mouseX -= 360f * Mathf.Sign(_mouseX);
        }

        yAxis *= _mouseSensitivity * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0f, _mouseX, 0f);
        _cam.Rotate(_mouseX, yAxis);
    }
}
