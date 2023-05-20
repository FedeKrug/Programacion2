using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [Header("Bullet")]
    [SerializeField] private Bullet _bullet;
    private Bullet _instBullet;

    [Header("Components")]
    [SerializeField] private Transform _target;
    [SerializeField] private float _bulletSpeed = 5f;
    [SerializeField] private float _bulletLifetime = 5f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _instBullet = Instantiate(_bullet, transform.position, transform.rotation);
            _instBullet.InitializeBullet(_target, _bulletSpeed, _bulletLifetime);
        }
    }
}
