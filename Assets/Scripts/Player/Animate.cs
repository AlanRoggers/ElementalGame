using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    private bool _flipX;
    private Rigidbody2D _phys;
    private Animator _anim;
    private HorizontalMovement _horiMov;
    private VerticalMovement _vertMov;
    private Vector3 _left;
    private Vector3 _right;

    void Awake()
    {
        _phys = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _horiMov = GetComponent<HorizontalMovement>();
        _vertMov = GetComponent<VerticalMovement>();
    }


    void Start()
    {
        _left = new Vector3(-1,1,1);
        _right = new Vector3(1,1,1);
    }


    void Update()
    {
        if (_horiMov.moveDetector != 0) {
            _flipX = _horiMov.moveDetector != 1;
            _anim.SetBool("Move", true);
            _anim.SetBool("Run", Input.GetKey(KeyCode.LeftShift));
        } else _anim.SetBool("Move", false);

        if (_flipX)
            transform.localScale = _left;
        else
            transform.localScale = _right;


    }
}
