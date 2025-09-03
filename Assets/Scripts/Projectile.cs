using UnityEngine;

public class Projectile : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rB;
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
    }

    void Update()
    {
        if (shake > 0)
        {
            cam.transform.position = new Vector2(Random.Range(-shake, shake), Random.Range(-shake, shake));
            shake -= Time.deltaTime * decreaseFactor;
        }
        if(shake <= 0)
        {
            shake = 0.0f;
            cam.transform.position = new Vector3(0, 0, -10);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player2"))
        {
            collision.gameObject.GetComponent<Player2>().TakeDamage(damage);
            GameObject hitParticle = Instantiate(HitParticle, transform.position, Quaternion.identity);
            hitParticle.transform.SetParent(null);
            shake = 100;
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            GameObject parryParticle = Instantiate(ParryParticle, transform.position, Quaternion.identity);
            parryParticle.transform.SetParent(null);
            shake = 50;
            Destroy(gameObject);
        }
    }
}
