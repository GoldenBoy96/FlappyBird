using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public Transform spawn;
    public Transform end;

    //public AudioClip clip;

    public GameObject pipePrefab;
    public GameObjectPool gameObjectPool;

    public float timeBetweenSpawn = 0.5f;

    public float randomYPipe = 5;

    private List<GameObject> onFieldPipe = new();

    private void Start()
    {
        gameObjectPool.CreatePool(pipePrefab, 10, transform);
        //Debug.Log(gameObjectPool.Size());
        StartCoroutine(SpawnPipe(timeBetweenSpawn));
    }

    private void Update()
    {
        KillEndPipe();
    }

    private void KillEndPipe()
    {
        foreach (GameObject pipe in onFieldPipe)
        {
            if (pipe.transform.position.x <= end.transform.position.x)
            {
                gameObjectPool.Push(pipe);
                onFieldPipe.Remove(pipe);
                return;
            }
        }
    }

    private IEnumerator SpawnPipe(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            GameObject pipe = gameObjectPool.Pop();
            if (pipe != null)
            {                
                onFieldPipe.Add(pipe);
                pipe.transform.position = spawn.transform.position;
                pipe.transform.position += new Vector3(0, Random.Range(-randomYPipe, randomYPipe), 0);
            }
            yield return null;
        }
    }
}
