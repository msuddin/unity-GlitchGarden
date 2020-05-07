using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
}
