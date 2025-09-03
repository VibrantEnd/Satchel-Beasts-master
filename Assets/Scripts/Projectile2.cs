using UnityEngine;

public class Projectile2 : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rB;
    BoxCollider2D bC;
    public float damage;
    private GameObject cam;
    private float shake = 0f;
    private float decreaseFactor = 1f;

    [SerializeField] private GameObject HitParticle;
    [SerializeField] private GameObject ParryParticle;
    void Awake()
    {
        cam = GameObject.FindWithTag("MainCamera");
        anim = GetComponent<Animator>();
        rB = GetComponent<Rigidbody2D>();
        bC = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shake > 0)
        {
            cam.transform.localPosition = Random.insideUnitSphere * shake;
            shake -= Time.deltaTime * decreaseFactor;
        }
        if(shake <= 0)
        {
            shake = 0.0f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player1"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            GameObject hitParticle = Instantiate(HitParticle, transform.position, Quaternion.identity);
            hitParticle.transform.SetParent(null);
            shake = 2;
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            GameObject parryParticle = Instantiate(ParryParticle, transform.position, Quaternion.identity);
            parryParticle.transform.SetParent(null);
            shake = 1;
            Destroy(gameObject);
        }

    }
}
