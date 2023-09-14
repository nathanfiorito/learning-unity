using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    public float moveSpeed = 0.05f;
    
    public Animator animator;
    public Transform player;

    private Rigidbody2D rb;
    private Vector2 movement;

    public float Health
    {
        set
        {
            print("healt");
            _healt = value;
            if(_healt <= 0)
            {
                animator.SetTrigger("hit");
                animator.SetBool("isAlive", false);
                Contador.instance.AddCount();
            }
            else
                animator.SetTrigger("hit");
        }
        get
        {
            return _healt;
        }
    }

    public float _healt = 3f;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", true);
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void OnHit(float damage)
    {
        Health -= damage;
    }

    void Destroy()
    {
        Destroy(gameObject);    
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("TESte");
    }
}
