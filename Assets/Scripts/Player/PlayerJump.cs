
using System;

using UnityEngine;

namespace Game.Player
{
	public class PlayerJump : MonoBehaviour
	{
		[SerializeField] private float _jumpForce;
		[SerializeField] private Rigidbody _rb;

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Jump();

			}
		}

		private void Jump()
		{
			_rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);

		}
	}
}

