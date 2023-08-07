using UnityEngine;
using UnityEngine.InputSystem;

public class BirdMovement : MonoBehaviour
{
    [Header("Movement Settings", order = 1)]
    [SerializeField] private InputAction birdFlap;

    #region Components
    private Rigidbody2D rb;
    private Animator animator;
    #endregion

    #region Parameters
    private bool isAlive = true;
    #endregion

    #region Methods
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

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
        AudioManager.Instance.Play(BirdManager.Instance.HitSound);
    }

    private bool CheckOutOfBoundary()
    {
        return transform.position.y > BirdManager.Instance.UpperBound || transform.position.y < BirdManager.Instance.LowerBound;
    }

    private void BirdFlap(InputAction.CallbackContext context)
    {
        if(isAlive && !CheckOutOfBoundary())
        {
            rb.velocity = new Vector2(0, 1 * BirdManager.Instance.FlapStrength) * Time.fixedDeltaTime;
            AudioManager.Instance.Play(BirdManager.Instance.FlapSound);
            PlayFlapAnimation();
        }
    }

    private void PlayUpFlapAnimation()
    {
        //transform.Rotate(new Vector3(0, 0, 300) * Time.deltaTime);
        animator.Play("Bird_UpFlap");
    }

    private void PlayDownFlapAnimation()
    {
        //transform.Rotate(new Vector3(0, 0, -300) * Time.deltaTime);
        animator.Play("Bird_DownFlap");
    }

    private void PlayFlapAnimation()
    {
        PlayUpFlapAnimation();
        Invoke(nameof(PlayDownFlapAnimation), BirdManager.Instance.FlapAnimationDelay);
    }
    #endregion
}
