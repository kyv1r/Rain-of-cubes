using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    private bool _isTouched = false;

    public Rigidbody Rigidbody { get; private set; }
    public Renderer Renderer { get; private set; }
    public MeshRenderer MeshRenderer { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(this._isTouched == true)
            return;

        if (collision.gameObject.tag == "Platform")
        {
            Destroy(gameObject, CalculateLifeTime());
            Renderer.material.color = Color.red;
            this._isTouched = true;
        }

    }

    private float CalculateLifeTime()
    {
        float lowLifeTime = 2.0f;
        float highLifeTime = 5.0f;

        return _lifeTime = UnityEngine.Random.Range(lowLifeTime, highLifeTime + 1);
    }
}
