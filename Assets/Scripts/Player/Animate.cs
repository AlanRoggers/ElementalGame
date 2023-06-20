using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    [SerializeField] private Animator _particleAnim;
    [SerializeField] private Transform _particleTrans;
    [SerializeField] private Vector3 _walkingPos;
    [SerializeField] private Vector3 _doubleJumpPos;
    private int _auxMoveDetector;
    private bool _flipX;
    private bool _walking;
    private Animator _anim;
    private HorizontalMovement _horiMov;
    private VerticalMovement _vertMov;
    private Attacks _attackInputs;
    private CollisionDetector _collisionDetector;
    private Rigidbody2D _phys;
    private Vector3 _left;
    private Vector3 _right;
    
    void Awake()
    {
        _phys = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _horiMov = GetComponent<HorizontalMovement>();
        _vertMov = GetComponent<VerticalMovement>();
        _collisionDetector = GetComponent<CollisionDetector>();
        _attackInputs = GetComponent<Attacks>();
    }


    void Start()
    {
        _auxMoveDetector = 0;
        _walking = false;
        _left = new Vector3(-1,1,1);
        _right = new Vector3(1,1,1);
    }


    void Update()
    {
        if (_horiMov.moveDetector != 0) {
            if ((!_walking || _auxMoveDetector != _horiMov.moveDetector) && _collisionDetector.onGround) {
                _particleTrans.localPosition = _walkingPos;
                _auxMoveDetector = _horiMov.moveDetector;
                _particleAnim.SetTrigger("StartWalk");
                _walking = true;
            }
            _flipX = _horiMov.moveDetector != 1;
            _anim.SetBool("Move", true);
            _anim.SetBool("Run", Input.GetKey(KeyCode.LeftShift));
        } else {
            _anim.SetBool("Move", false);
            _walking = false;
        }

        if (_flipX)
            transform.localScale = _left;
        else
            transform.localScale = _right;


        if (!_collisionDetector.onGround){
            
            if(_vertMov.doubleJumpDetector){
                _particleTrans.localPosition = _doubleJumpPos;
                _particleAnim.SetTrigger("DoubleJump");
            }

            _anim.SetBool("OnGround", false);
            
            if(_phys.velocity.y >= 0)
                _anim.SetBool("Jump", true);
            else
                _anim.SetBool("Jump", false);
        } else {
            _anim.SetBool("OnGround", true);
            _anim.SetBool("Jump", false);
        }

        if(_attackInputs.attack1)
            _anim.SetTrigger("Attack1");
            
    }
}
