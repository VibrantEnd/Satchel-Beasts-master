using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float Health;
    [SerializeField] float MaxHealth;

    [SerializeField] GameObject Projectile;
    [SerializeField] Color AttackColor;
    [SerializeField] float Damage;
    [SerializeField] float Cooldown;
    float Coolup;
    float attackAnim = 0.5f;
    float attackAnimReduce;
    [SerializeField] float Range;
    [SerializeField] float AttackSpeed;

    public Transform Aim;

    private bool isAttacking;
    private bool isWalking;

    Animator animator;
    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;
    private float spriteColorTimer = .2f;
    private Vector2 input;
    private Vector2 lastMoveDirection;
    private bool facingLeft = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Coolup = Cooldown;
    }
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.KeypadEnter) && attackAnimReduce <= 0)
        {
            animator.SetBool("Attack", true);
            isAttacking = true;
            Attack();
        }
        Animate();
        Cooldown -= Time.deltaTime;
        attackAnimReduce -= Time.deltaTime;
        if (attackAnimReduce <= 0)
        {
            isAttacking = false;
            animator.SetBool("Attack", false);
        }
        spriteColorTimer -= Time.deltaTime;
        if (spriteColorTimer <= 0)
        {
            spriteRenderer.color = Color.white;
        }
        if (input.x < 0 && !facingLeft || input.x > 0 && facingLeft)
        {
            Flip();
        }

    }
    private void FixedUpdate()
    {
        rigidBody.linearVelocity = input * Speed;
        if (isWalking)
        {
            Vector3 vector3 = Vector3.left * input.x + Vector3.down * input.y;
            Aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
            Aim.position = transform.position;
        }
    }
    void Movement()
    {
        float moveX = Input.GetAxisRaw("P2Horiz");
        float moveY = Input.GetAxisRaw("P2Vert");

        if ((moveX == 0 && moveY == 0) && (input.x != 0 || input.y != 0))
        {
            lastMoveDirection = input;
            Vector3 vector3 = Vector3.left * lastMoveDirection.x + Vector3.down * lastMoveDirection.y;
            Aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
        }
        input.x = Input.GetAxisRaw("P2Horiz");
        input.y = Input.GetAxisRaw("P2Vert");
        input.Normalize();
    }
    void Animate()
    {
        if ((input.x == 0 && input.y == 0) && !isAttacking)
        {
            animator.SetBool("IsWalking", false);
            isWalking = false;
        }
        else if ((input.x != 0 || input.y != 0) && !isAttacking)
        {
            animator.SetBool("IsWalking", true);
            isWalking = true;
        }

    }
    void Attack()
    {
        if (Cooldown <= 0)
        {
            Cooldown = Coolup;
            attackAnimReduce = attackAnim;
            GameObject instProjectile = Instantiate(Projectile, Aim.position, Aim.rotation);
            instProjectile.GetComponent<SpriteRenderer>().material.color = AttackColor;
            instProjectile.GetComponent<Rigidbody2D>().AddForce(-Aim.up * AttackSpeed + new Vector3(rigidBody.linearVelocity.x, rigidBody.linearVelocity.y, 0), ForceMode2D.Impulse);
            Destroy(instProjectile, Range);
        }
    }
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingLeft = !facingLeft;
    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
        spriteRenderer.color = Color.red;
        spriteColorTimer = .2f;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
