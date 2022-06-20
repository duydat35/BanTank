using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] ParticleSystem shellExplosion;

    public float maxLifeTime = 2f;
    void Start()
    {
        //Destroy(gameObject, maxLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        shellExplosion.transform.parent = null;
        shellExplosion.Play();
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().TakeDamage(10);
        }
        Destroy(gameObject);
        
    }
}
