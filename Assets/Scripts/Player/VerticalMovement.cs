using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    private Rigidbody2D phys;
    private CollisionDetector collisionDetector;


    void Awake()
    {
        phys = GetComponent<Rigidbody2D>();
        collisionDetector = GetComponent<CollisionDetector>();
    }


    void Update()
    {
        phys.gravityScale = !collisionDetector.onGround ? 10f : 0f;
    }
}
