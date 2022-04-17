using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float Health;

    private void Update()
    {
        if (Health <= 0) Destroy(gameObject);
    }

    public void TakeDamage(float Damage)
    {
        Health -= Damage;
    }
}
