using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    //Variables temporales (Las voy a borrar)
    public float terrainFriction;

    //El valor de moveForce siempre debe ser mayor a cualquier constante de friccion
    [SerializeField] private float weight;
    [SerializeField] private float moveForce; 
    [SerializeField] private float friction;
    private float acceleration;
    private Rigidbody2D phys;
    private Vector2 velocity;
    private CollisionDetector collisionDetector;

    void Awake()
    {
        phys = GetComponent<Rigidbody2D>();
        collisionDetector = GetComponent<CollisionDetector>();
    }
    
    void Start()
    {
        acceleration = 0;
    }

    void FixedUpdate()
    {
        velocity.y = phys.velocity.y;
        // Deteccion de las teclas de movimiento y validación de ambas teclas presionadas
        int moveDetector =  (Input.GetKey(KeyCode.D) ^ Input.GetKey(KeyCode.A)) ? 
                            (Input.GetKey(KeyCode.D) ? 
                                1: 
                            (Input.GetKey(KeyCode.A) ? 
                                -1 : 
                            0)) : 0;

        // Coeficiente de friccion
        friction = collisionDetector.objectCollTag switch
        {
            "Terrain" => terrainFriction,
            "Air" => 0.5f,
            _ => 0f,
        };
        
        // Se acelera con un tope de velocidad en 10 o -10 (En teoría no debería afectar el sistema de fisicas de unity a 
        // esta parte del movimiento)
        if (moveDetector != 0 && collisionDetector.onGround) {
            acceleration += (Mathf.Sign(moveDetector) * moveForce - Mathf.Sign(moveDetector) * friction) * Time.deltaTime;
            acceleration = Mathf.Clamp(acceleration, -10, 10);
        } else if (acceleration != 0f) {
            float deceleration = (-1) * Mathf.Sign(acceleration) * friction * Time.deltaTime * weight;
            acceleration = Mathf.Sign(acceleration) == 1 ? 
                (acceleration + deceleration > 0.9 ? acceleration + deceleration : 0) : 
                (acceleration + deceleration < -0.9 ? acceleration + deceleration : 0);
            // print(deceleration);
        }
        velocity.x = acceleration;
        phys.velocity = velocity;
        // print(acceleration);
    }

}
