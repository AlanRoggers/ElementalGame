using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool changingDirection;
    [SerializeField] private Vector2 _velocity;
    private Rigidbody2D _phys;
    private Collisions _collisionDetector;

    void Awake()
    {
        _phys = GetComponent<Rigidbody2D>();
        _collisionDetector = GetComponent<Collisions>();
    }

    void Start()
    {
        changingDirection = false;
    }

    void Update()
    {
        if(!_collisionDetector.onGround && !changingDirection){
            _velocity *= -1;
            changingDirection = true;
            StartCoroutine(ChangeDirectionTreshhold());
        }

        _phys.velocity = _velocity;
    }

    IEnumerator ChangeDirectionTreshhold()
    {
        yield return new WaitForSeconds(0.5f);
        changingDirection = false;
    }
}
