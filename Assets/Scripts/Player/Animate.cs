using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    private bool _flipX;
    private Rigidbody2D _phys;
    private Animator _anim;
    private Vector3 _left;
    private Vector3 _right;

    void Awake()
    {
        _phys = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }


    void Start()
    {
        _left = new Vector3(-1,1,1);
        _right = new Vector3(1,1,1);
    }


    void Update()
    {
        if (Mathf.Abs(_phys.velocity.x) > 0) {
            _flipX = _phys.velocity.x < 0;
            _anim.SetBool("Move", true);
        } else _anim.SetBool("Move", false);

        if (_flipX)
            transform.localScale = _left;
        else
            transform.localScale = _right;


    }
}
