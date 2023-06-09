using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{   
    public bool jumpDetector;
    public bool doubleJumpDetector;
    private bool _canDouble;
    [SerializeField] private float _jumpForce;
    private Rigidbody2D _phys;
    private CollisionDetector _collisionDetector;
    private Vector2 _velocity;

    void Awake()
    {
        jumpDetector = false;
        doubleJumpDetector = false;
        _phys = GetComponent<Rigidbody2D>();
        _canDouble = true;
        _collisionDetector = GetComponent<CollisionDetector>();
    }


    void Update()
    {
        jumpDetector = jumpDetector || Input.GetKeyDown(KeyCode.W) && _collisionDetector.onGround;

        doubleJumpDetector = Input.GetKeyDown(KeyCode.W) && !_collisionDetector.onGround && _canDouble;

        _phys.gravityScale = !_collisionDetector.onGround ? 10f : 
            Mathf.Abs(_phys.velocity.y) > 0f ? 1f : 0f;
        
        if (Input.GetKeyUp(KeyCode.W) && _phys.velocity.y > 0)
            _phys.velocity = new Vector2(_phys.velocity.x, _phys.velocity.y / 2f);

        if (_collisionDetector.onGround)
            _canDouble = true;

        if(doubleJumpDetector){
            _canDouble = false;
            _velocity.y = _jumpForce - 5f;
            _phys.velocity = _velocity;
            _velocity.y = 0f;
        }

    }

    void FixedUpdate(){
        _velocity.x = _phys.velocity.x;

        if (jumpDetector){
            _velocity.y = _jumpForce;
            _phys.velocity = _velocity;
            _velocity.y = 0f;
            jumpDetector = false;
        } else if (_collisionDetector.onGround) {
            _velocity.y = 0;
            _phys.velocity = _velocity;
        }

    }
}
