using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private float _repeatRate = 1f;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    private bool _isSpawned = true;

    private ObjectPool<Cube> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>
        (
            createFunc: () => Instantiate(_cubePrefab),
            actionOnGet: (cube) => OnGet(cube),
            actionOnRelease: (cube) => OnReleaseCube(cube),
            actionOnDestroy: (cube) => Destroy(cube),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
        );
    }

    private void Start()
    {
        StartCoroutine(InstantiateCube());
    }

    private void OnGet(Cube cube)
    {
        cube.Touched += OnReleaseCube;
        cube.transform.position = transform.localPosition + Random.insideUnitSphere * 5;
        cube.gameObject.SetActive(true);
        ReleaseCube(cube);
    }

    private void OnReleaseCube(Cube cube)
    {
        cube.Touched -= OnReleaseCube;
        StartCoroutine(ReleaseCube(cube));
    }

    private IEnumerator ReleaseCube(Cube cube)
    {
        WaitForSeconds lifeTime = new WaitForSeconds(cube.CalculateLifeTime());
        yield return lifeTime;
        _pool.Release(cube);
        cube.gameObject.SetActive(false);
    }

    private IEnumerator InstantiateCube()
    {
        while (_isSpawned)
        {
            WaitForSeconds _repeatRate = new WaitForSeconds(1);
            _pool.Get();
            yield return _repeatRate;
        }
    }
}
