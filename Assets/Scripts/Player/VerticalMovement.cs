using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    private bool _jumpDetector;
    private Rigidbody2D _phys;
    private CollisionDetector collisionDetector;
    private Vector2 _velocity;

    void Awake()
    {
        _phys = GetComponent<Rigidbody2D>();
        collisionDetector = GetComponent<CollisionDetector>();
    }


    void Update()
    {
        _jumpDetector = _jumpDetector || Input.GetKeyDown(KeyCode.W) && collisionDetector.onGround;

        _phys.gravityScale = !collisionDetector.onGround ? 10f : 
            Mathf.Abs(_phys.velocity.y) > 0f ? 1f : 0f;

    }

    void FixedUpdate(){
        _velocity.x = _phys.velocity.x;
        if (_jumpDetector){
            _velocity.y = _jumpForce;
            _phys.velocity = _velocity;
            _velocity.y = 0f;
            _jumpDetector = false;
        } else if (collisionDetector.onGround) {
            _velocity.y = 0;
            //_phys.velocity = _velocity;
        }
    }
}
