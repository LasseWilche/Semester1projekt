using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [Header("Settings")]
    public int shieldHP = 1;
    public float opacity = 0.4f;
    public float animationSpeed = 1f;

    private SpriteRenderer sr;
    private Animator animator;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        // Apply transparency
        Color c = sr.color;
        c.a = opacity;
        sr.color = c;

        // Set animation speed if using Animator
        if (animator != null)
            animator.speed = animationSpeed;
    }

    /// <summary>
    /// Called by the enemy when the shield should take damage.
    /// </summary>
    public void DamageShield()
    {
        shieldHP--;

        if (shieldHP <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            // Optional hit animation
            animator.SetTrigger("Hit");
        }
    }
}
