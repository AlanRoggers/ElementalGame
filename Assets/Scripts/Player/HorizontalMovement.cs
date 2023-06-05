using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    //El valor de moveForce siempre debe ser mayor a cualquier constante de friccion
    [SerializeField] private float weight;
    [SerializeField] private float moveForce; 
    private float constFriction = 0;
    private float acceleration;
    private Rigidbody2D phys;
    private Vector2 velocity;
    void Awake(){
        phys = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        acceleration = 0;
    }

    void Update()
    {
        // Deteccion de las teclas de movimiento y validación de ambas teclas presionadas
        int moveDetector =  (Input.GetKey(KeyCode.D) ^ Input.GetKey(KeyCode.A)) ? 
                            (Input.GetKey(KeyCode.D) ? 
                                1: 
                            (Input.GetKey(KeyCode.A) ? 
                                -1 : 
                            0)) : 0;

        // Se acelera con un tope de velocidad en 10 o -10 (En teoría no debería afectar el sistema de fisicas de unity a 
        // esta parte del movimiento)

        if (moveDetector != 0) {
            acceleration += (Mathf.Sign(moveDetector) * moveForce - Mathf.Sign(moveDetector) * constFriction) * Time.deltaTime;
            acceleration = Mathf.Clamp(acceleration, -10, 10);
        } else {
            acceleration += (-1) * Mathf.Sign(acceleration) * constFriction * Time.deltaTime * weight;
            acceleration = (acceleration > 0.9 ^ acceleration < -0.9) ? acceleration : 0;
        }

        velocity.x = acceleration;  
        phys.velocity = velocity;
        //print(acceleration);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Terrain")) 
            constFriction = collision.gameObject.GetComponent<PhysicScalars>().friction;
    }

}
