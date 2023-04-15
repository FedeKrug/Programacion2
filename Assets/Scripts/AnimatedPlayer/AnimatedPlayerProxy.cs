using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedPlayerProxy : MonoBehaviour
{
    [SerializeField] private AnimatedPlayer _player;

    private void Start()
    {
        _player = GetComponentInParent<AnimatedPlayer>();
    }

    private void OnStartAttack()
    {

    }
}
