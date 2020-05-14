using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float damageAmount = 50f;


    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if (attacker && health)
        {
            health.DealDamage(damageAmount);
            Destroy(gameObject);
        }
        
    }
}
