using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class FPSPlayer : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField, Range(1, 2000)] private float _mouseSensibility = 100;
    [SerializeField] private Transform _head;


    private Rigidbody _rb;
    private FPSCamera _cam;
    private float _xAxis, _zAxis, _inputMouseX, _inputMouseY, _mouseX;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _rb = GetComponent<Rigidbody>();
        _cam = Camera.main.GetComponent<FPSCamera>();
    }

    private void Update()
    {
        _xAxis = Input.GetAxis("Horizontal");
        _zAxis = Input.GetAxis("Vertical");

        _inputMouseX = Input.GetAxisRaw("Mouse X");
        _inputMouseY = Input.GetAxisRaw("Mouse Y");

        if (_inputMouseX!=0 || _inputMouseY != 0)
        {

        }
    }
    private void FixedUpdate()
    {
        Movement(_xAxis,_zAxis);
    }

    private void Movement(float xAxis, float zAxis)
    {
        Vector3 dir = (transform.right * xAxis + transform.forward * zAxis).normalized;
        _rb.MovePosition(transform.position += dir * _movementSpeed * Time.fixedDeltaTime);
    }
    private void Rotation(float xAxis, float zAxis)
    {
        _mouseX = xAxis * _mouseSensibility * Time.deltaTime;
        if (_mouseX>= 360 || _mouseX<= -360)

        {
        }
    }


}
public class FPSCamera : MonoBehaviour
{
    [SerializeField] private Transform _playerHead;
    [SerializeField, Range(-90, 90)] private float _minClampY, _maxClampY;

}

