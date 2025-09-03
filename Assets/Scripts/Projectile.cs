using UnityEngine;

public class Projectile : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rB;
    public float damage;
    void Awake()
    {
        anim = GetComponent<Animator>();
        rB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player2"))
        {
            collision.gameObject.GetComponent<Player2>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
