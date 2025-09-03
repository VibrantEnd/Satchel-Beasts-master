using UnityEngine;

public class Projectile : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rB;
    public float damage;
    [SerializeField] private Camera cam;
    private float shake = 0f;
    private float decreaseFactor = 1f;

    [SerializeField] private GameObject HitParticle;
    [SerializeField] private GameObject ParryParticle;
    void Awake()
    {
        anim = GetComponent<Animator>();
        rB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shake > 0)
        {
            cam.transform.localPosition = Random.insideUnitSphere * shake;
            shake -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shake = 0.0f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player2"))
        {
            collision.gameObject.GetComponent<Player2>().TakeDamage(damage);
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
