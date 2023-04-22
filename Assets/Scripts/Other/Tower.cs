using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform _target;
    [SerializeField] private float _distanceToActivate;


    [Header("Aesthetics")]
    [SerializeField] private List<MeshRenderer> _meshes = new List<MeshRenderer>();

    private float _distance;
    private List<Material> _materials = new List<Material>();

    private bool _isOn;


    private void Start()
    {
        foreach (var mesh in _meshes)
        {
            _materials.Add(mesh.material);
        }
        if (_target == null)
        {
            _target = FindObjectOfType<AnimatedPlayer>().transform;
        }

    }

    private void Update()
    {
        //_distance = Vector3.Distance(transform.position, _target.position); //devuelve la magnitud conseguida a través de Pitágoras de 2 Vector3 que le damos
        _distance = (transform.position - _target.position).sqrMagnitude;

        if (_distance<= Mathf.Pow(_distanceToActivate,2))
        {
            Debug.Log($"En zona");
        }
        Debug.Log($"Distancia entre {name} y {_target.gameObject.name}: {Mathf.Round(_distance)}.");
    }

}
