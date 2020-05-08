using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVfx;

    float dealthDealyOfParticleEffect = 2f;

    public void DealDamage(float damage)
    {
        this.health -= damage;

        if (health <= 0)
        {
            TriggerDeathVfx();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVfx()
    {
        var explosion = Instantiate(deathVfx, transform.position, transform.rotation);
        Destroy(explosion, dealthDealyOfParticleEffect);
    }
}
