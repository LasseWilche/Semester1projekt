using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Animator))]
public class Meleescript : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float meleeSpeed = 0.35f;

    private float timeUntilMelee;
    private Vector2 lastMoveDir = Vector2.down;

    // Brug hashes for at undgå stavefejl
    private static readonly int HashAttack = Animator.StringToHash("Attack");
    private static readonly int HashAttackX = Animator.StringToHash("AttackX");
    private static readonly int HashAttackY = Animator.StringToHash("AttackY");

    void Awake()
    {
        // Auto-wire hvis feltet er tomt eller animatoren sidder på et child
        if (!anim) anim = GetComponentInChildren<Animator>();
        if (!anim)
        {
            Debug.LogError("[Meleescript] Ingen Animator fundet på objekt eller children.");
            return;
        }
        Debug.Log($"[Meleescript] Bruger Animator-controller: {anim.runtimeAnimatorController?.name ?? "<none>"}");

        // Tjek at parametrene findes og er af korrekt type
        bool hasAttack = false, hasX = false, hasY = false;
        foreach (var p in anim.parameters)
        {
            if (p.nameHash == HashAttack && p.type == AnimatorControllerParameterType.Trigger) hasAttack = true;
            if (p.nameHash == HashAttackX && p.type == AnimatorControllerParameterType.Float) hasX = true;
            if (p.nameHash == HashAttackY && p.type == AnimatorControllerParameterType.Float) hasY = true;
        }
        if (!hasAttack || !hasX || !hasY)
            Debug.LogError($"[Meleescript] Mangler Animator-parametre: " +
                           $"{(hasAttack ? "" : "Attack(trigger) ")}" +
                           $"{(hasX ? "" : "AttackX(float) ")}" +
                           $"{(hasY ? "" : "AttackY(float) ")}");
    }

    void Update()
    {
        // Opdater facing (låst til cardinal retning)
        if (Keyboard.current != null)
        {
            int x = (Keyboard.current.aKey.isPressed ? -1 : 0) + (Keyboard.current.dKey.isPressed ? 1 : 0);
            int y = (Keyboard.current.sKey.isPressed ? -1 : 0) + (Keyboard.current.wKey.isPressed ? 1 : 0);
            Vector2 raw = new Vector2(x, y);
            if (raw != Vector2.zero) lastMoveDir = (Mathf.Abs(raw.x) >= Mathf.Abs(raw.y))
                                                ? new Vector2(Mathf.Sign(raw.x), 0f)
                                                : new Vector2(0f, Mathf.Sign(raw.y));
        }

        if (timeUntilMelee > 0f) { timeUntilMelee -= Time.deltaTime; return; }

        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (!anim) return;

            anim.SetFloat(HashAttackX, lastMoveDir.x);
            anim.SetFloat(HashAttackY, lastMoveDir.y);
            anim.SetTrigger(HashAttack);

            Debug.Log($"[Meleescript] Attack -> dir=({lastMoveDir.x},{lastMoveDir.y}), controller={anim.runtimeAnimatorController?.name}");
            timeUntilMelee = meleeSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Tjek om det, du rammer, er et monster
        if (other.CompareTag("Enemy"))
        {
            // Hent enemy-scriptet og kald dens "Die" metode
            EnemyHealthManager enemy = other.GetComponent<EnemyHealthManager>();
            if (enemy != null)
            {
                enemy.Dying();
            }
        }
    }


}

