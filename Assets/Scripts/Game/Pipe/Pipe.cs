using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed;

    public Transform topPipe;
    public Transform bottomPipe;

    private void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;
    }

    
}
