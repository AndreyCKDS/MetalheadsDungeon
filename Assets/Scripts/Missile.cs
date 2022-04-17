using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float Distance;
    [SerializeField] private float Damage;
    [SerializeField] private LayerMask Solid;
    private RaycastHit2D HitInfo;

    private void Update()
    {
        HitInfo = Physics2D.Raycast(transform.position, transform.up, Distance, Solid);

        if (HitInfo.collider != null)
        {
            HitInfo.collider.GetComponent<Enemy>().TakeDamage(Damage);
        }
        Destroy(gameObject);
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }
}
