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

    [SerializeField] private Color _activationColor;
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
        _distance = (transform.position - _target.position).sqrMagnitude; //esto es más útil si no necesitamos expresamente la distancia entre dos objetos.

        if (_distance <= Mathf.Pow(_distanceToActivate, 2) && !_isOn)
        {
            Debug.Log($"En zona");
        }
        Debug.Log($"Distancia entre {name} y {_target.gameObject.name}: {Mathf.Round(_distance)}.");

        foreach (var mat in _materials)
        {
            StartCoroutine(CO_OntriggerEnter(mat));
        }
    }

    public void OnHit(float damage, string damager) //
    {
        Debug.Log($"Tower has been damaged from {damager} and lost {damage} points of life.");
        if (!_isOn)
        {
            
        }

    }
    IEnumerator CO_OntriggerEnter(Material material)
    {
        _isOn = !_isOn;
        var ogColor = material;
        material.color = _activationColor;
        yield return new WaitForSeconds(1f);
        material = ogColor;
        _isOn = !_isOn;
    }
}
