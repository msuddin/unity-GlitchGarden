using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shreadder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        FindObjectOfType<Lives>().TakeLive();
        Destroy(otherCollider.gameObject);
    }
}
