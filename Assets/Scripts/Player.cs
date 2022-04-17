using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed;

    private Rigidbody2D RB;
    private Animator Anim;
    private Vector2 MoveInput;
    private Vector2 MoveVelocity;


    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Anim.SetFloat("LastX", 1);
        Anim.SetFloat("LastY", 0);
    }

    void Update()
    {
        MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        MoveVelocity = MoveInput.normalized * Speed;
        Anim.SetFloat("Horizontal", MoveInput.x);
        Anim.SetFloat("Vertical", MoveInput.y);
        Anim.SetFloat("Speed", MoveInput.sqrMagnitude);
        if ((MoveInput.x != 0) ^ (MoveInput.y != 0))
        {
            Anim.SetFloat("LastX", MoveInput.x);
            Anim.SetFloat("LastY", MoveInput.y);
        }
    }

    void FixedUpdate()
    {
        RB.MovePosition(RB.position + MoveVelocity * Time.fixedDeltaTime);
    }
}
