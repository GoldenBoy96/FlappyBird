using UnityEngine;

public class BirdManager : MonoBehaviour
{
    [Header("Animations")]
    [Header("Audio")]
    public AudioClip FlapSound;
    public AudioClip HitSound;
    [Header("Sprites")]
    [Header("Stats")]
    public float FlapStrength = 200f;
    public float UpperBound = 20f;
    public float LowerBound = -20f;
    public float FlapAnimationDelay = 0.1f;

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
