using UnityEngine;

public class BirdManager : MonoBehaviour
{
    [Header("Animations")]
    [Header("Audio")]
    public AudioClip FlapSound;
    [Header("Sprites")]

    // Singleton instance
    public static BirdManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
