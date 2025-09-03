using UnityEngine;

public class Projectile2 : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rB;
    BoxCollider2D bC;
    public float damage;

    [SerializeField] private GameObject HitParticle;
    [SerializeField] private GameObject ParryParticle;
    void Awake()
    {
        anim = GetComponent<Animator>();
        rB = GetComponent<Rigidbody2D>();
        bC = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player1"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            GameObject hitParticle = Instantiate(HitParticle, transform.position, Quaternion.identity);
            hitParticle.transform.SetParent(null);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            GameObject parryParticle = Instantiate(ParryParticle, transform.position, Quaternion.identity);
            parryParticle.transform.SetParent(null);
            Destroy(gameObject);
        }

    }
}
