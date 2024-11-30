using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class Platform : MonoBehaviour
{
    public Rigidbody Rigidbody { get; private set; }
    public Renderer Renderer { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Renderer = GetComponent<Renderer>();
    }
}
