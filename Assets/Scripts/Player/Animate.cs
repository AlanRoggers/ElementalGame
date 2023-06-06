using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _phys;
    private Animator _anim;

    void Awake()
    {
        _phys = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (Mathf.Abs(_phys.velocity.x) > 0) {
            _spriteRenderer.flipX = _phys.velocity.x < 0;
            _anim.SetBool("Move", true);
        } else _anim.SetBool("Move", false);
    }
}
