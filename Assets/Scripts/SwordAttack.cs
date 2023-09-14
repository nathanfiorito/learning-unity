using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    public float swordDamage = 1f;
    Vector2 rightAttackOffset;

    private void Start()
    {
        rightAttackOffset = transform.position;
        if (swordCollider == null)
        {
            Debug.LogWarning("SwordCollider is missing!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        IDamagable damagableObject = collision.collider.GetComponent<IDamagable>();


        if (damagableObject != null)
        {
            collision.collider.SendMessage("OnHit", swordDamage);
            damagableObject.OnHit(swordDamage);
        }
        else
        {
            Debug.LogWarning("Collider does not implement IDamagable");
        }
    }

    void IsFacingRight(bool isFacingRight)
    {
        if (isFacingRight)
            transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y - 0.09f);
        else
            transform.localPosition = new Vector3(rightAttackOffset.x, rightAttackOffset.y - 0.09f);
    }
}
