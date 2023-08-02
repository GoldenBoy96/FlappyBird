using UnityEngine;
using UnityEngine.InputSystem;

public class BirdMovement : MonoBehaviour
{
    [Header("Movement Settings", order = 1)]
    [SerializeField] private float flapStrength = 10f;
    [SerializeField] private InputAction birdFlap;

    [Header("Restrictions", order = 2)]
    [SerializeField] private float upperDeathBound = 20f;
    [SerializeField] private float lowerDeathBound = -20f;

    [SerializeField]private AudioClip flapEffect;

    #region Components
    private Rigidbody2D rb;
    #endregion

    #region Parameters
    private bool isAlive = true;
    #endregion

    #region Methods
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (CheckOutOfBoundary())
        {
            isAlive = false;
        }
    }

    private void OnEnable()
    {
        birdFlap.Enable();
        birdFlap.performed += BirdFlap;
    }

    private void OnDisable()
    {
        birdFlap.Disable();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isAlive = false;
    }

    private bool CheckOutOfBoundary()
    {
        return transform.position.y > upperDeathBound || transform.position.y < lowerDeathBound;
    }

    private void BirdFlap(InputAction.CallbackContext context)
    {
        if(isAlive)
        {
            rb.velocity = Vector2.up * flapStrength;
            AudioManager.Instance.Play(BirdManager.Instance.FlapSound);
        }
    }
    #endregion
}
