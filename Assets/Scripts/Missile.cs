using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float TargetColliderOffset;
    [SerializeField] private float Damage;
    [SerializeField] private LayerMask Solid;
    private RaycastHit2D HitInfo;
    [SerializeField] private Sprite[] NoteSprites;
    private SpriteRenderer SpriteRenderer;

    private void Start()
    {
        int rand = Random.Range(0, NoteSprites.Length);
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = NoteSprites[rand];
    }

    private void Update()
    {
        HitInfo = Physics2D.Raycast(transform.position, transform.up, TargetColliderOffset, Solid);

        if (HitInfo.collider != null)
        {
            HitInfo.collider.GetComponent<Enemy>().TakeDamage(Damage);
            Destroy(gameObject);
        }
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }
}
