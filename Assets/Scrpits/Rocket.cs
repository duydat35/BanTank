using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] ParticleSystem rocketExplosion;
    public float maxLifeTime = 5f;
    void Start()
    {
        //Destroy(gameObject, maxLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        rocketExplosion.transform.parent = null;
        rocketExplosion.Play();
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().TakeDamage(40);
        }
        Destroy(gameObject);
    }
}
