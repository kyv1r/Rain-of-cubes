using System;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Platform _platform;

    private bool _isTouched = false;

    public event Action<Cube> Touched;

    public Rigidbody Rigidbody { get; private set; }
    public Renderer Renderer { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(_isTouched == true)
            return;

        if (collision.gameObject.GetComponent<Platform>())
        {
            Renderer.material.color = Color.red;
            _isTouched = true;
            Touched?.Invoke(this);
        }
    }

    public float CalculateLifeTime()
    {
        float lowLifeTime = 2.0f;
        float highLifeTime = 5.0f;

        return UnityEngine.Random.Range(lowLifeTime, highLifeTime);
    }
}
