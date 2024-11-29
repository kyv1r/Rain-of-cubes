using UnityEngine;
using UnityEngine.Pool;

public class Cube : MonoBehaviour
{
    public Rigidbody Rigidbody {  get; private set; }
    public Renderer Renderer {  get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Renderer = GetComponent<Renderer>();
    }
}
