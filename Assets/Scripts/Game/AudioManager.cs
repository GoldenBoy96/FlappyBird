using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Players Components")]
    public AudioSource EffectSource;
    public AudioSource MusicSource;

    // Singleton instance
    public static AudioManager Instance { get; private set; } = null;

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
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
