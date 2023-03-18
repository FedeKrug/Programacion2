using System;

using UnityEngine;

namespace Game.Player
{
	public class PlayerMovementByRigidBody : MonoBehaviour
	{
		[SerializeField] Rigidbody _rb;
		[SerializeField, Range(0, 200)] private float _minSpeed, _maxSpeed;
		private float _speed;
		private float _xAxis, _zAxis;

		private void Awake()
		{
			_speed = _minSpeed;
		}
		private void Update()
		{
			_xAxis = Input.GetAxisRaw("Horizontal");
			_zAxis = Input.GetAxisRaw("Vertical");


			if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
			{
				_speed = _maxSpeed;
			}
			if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
			{
				_speed = _minSpeed;

			}
		}
		private void FixedUpdate()
		{
			if (_xAxis != 0 || _zAxis != 0)
			{
				MoveWithPhysics(_xAxis, _zAxis);

			}
		}

		private void MoveWithPhysics(float xAxis, float zAxis)
		{
			var dir = transform.right * xAxis + transform.forward * zAxis;

			_rb.velocity += dir * _speed * Time.fixedDeltaTime;
		}
	}

}

