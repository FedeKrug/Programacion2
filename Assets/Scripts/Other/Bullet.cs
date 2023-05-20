using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody _rb;
    private float _bulletLifetime;
    private float _bulletSpeed;

    public void InitializeBullet(Transform target, float bulletSpeed, float bulletLifetime)
    {
        _rb = GetComponent<Rigidbody>();
        _bulletLifetime = bulletLifetime;
        _bulletSpeed = bulletSpeed;
        Vector3 dir = (target.position - transform.position).normalized;
        StartCoroutine(crBulletBehaviour(target, dir));
    }

    private IEnumerator crBulletBehaviour(Transform target, Vector3 dir)
    {        
        float tick = 0f;

        while(tick <= 1f)
        {            
            _rb.MovePosition(transform.position += dir * _bulletSpeed * Time.deltaTime);
            tick += Time.deltaTime / _bulletLifetime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
