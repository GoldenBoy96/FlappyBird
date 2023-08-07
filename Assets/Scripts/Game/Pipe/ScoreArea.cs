using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Bird"))
        {
            GameManager.Instance.score++;
            //Debug.Log(GameManager.Instance.score);
            EventDispatcher.Instance.PostEvent(EventID.OnScoreChange, this);
        }
    }

}
