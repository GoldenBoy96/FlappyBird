using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public Transform spawn;
    public Transform end;

    public GameObject pipePrefab;
    GameObjectPool gameObjectPool = new();

    private void Start()
    {
        gameObjectPool.CreatePool(pipePrefab, 5, transform);
    }
}
