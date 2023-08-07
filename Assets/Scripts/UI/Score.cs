using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] GameObject scoreUI;

    private TextMeshProUGUI scoreText ;

    private void Start()
    {
        scoreText = scoreUI.GetComponent<TextMeshProUGUI>();
        EventDispatcher.Instance.RegisterListener(EventID.OnScoreChange, (param) => OnScoreChange());
    }

    void OnScoreChange()
    {
        scoreText.text = GameManager.Instance.score.ToString();
        Debug.Log("Test event listener | " + GameManager.Instance.score);
    }
}
