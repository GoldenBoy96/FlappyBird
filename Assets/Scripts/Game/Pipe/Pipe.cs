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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Bird"))
        {
            GameManager.Instance.score++;
            Debug.Log(GameManager.Instance.score);
        }

    }
}
