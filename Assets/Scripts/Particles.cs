using System.Timers;
using UnityEngine;

public class Particles : MonoBehaviour
{
    private float lifetime = 1f;

    void Update()
    {
        if(lifetime < 0)
        {
            Destroy(gameObject);
        }
        lifetime -= Time.deltaTime;
    }
}
