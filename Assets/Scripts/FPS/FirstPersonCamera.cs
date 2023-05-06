using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [Header("Rotation")]
    [Range(-90f, 90)][SerializeField] private float _yMinClamp = -60f;
    [Range(-90f, 90)][SerializeField] private float _yMaxClamp = 75f;

    private Transform _playerHead;
    private float _mouseY;

    public void SetHead(Transform head)
    {
        _playerHead = head;
    }

    private void LateUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position = _playerHead.position;
    }

    public void Rotate(float xAxis, float yAxis)
    {
        _mouseY += yAxis;
        _mouseY = Mathf.Clamp(_mouseY, _yMinClamp, _yMaxClamp);
        transform.rotation = Quaternion.Euler(-_mouseY, xAxis, 0f);
    }
}
