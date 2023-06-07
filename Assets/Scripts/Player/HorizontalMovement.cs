using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    //Variables temporales (Las voy a borrar)
    public float terrainFriction;

    //El valor de moveForce siempre debe ser mayor a cualquier constante de friccion
    [SerializeField] private float _weight;
    [SerializeField] private float _moveForce; 
    [SerializeField] private float _friction;
    public int moveDetector;
    private float _maxSpeed;
    private float _acceleration;
    private bool _isJumping;
    private Rigidbody2D _phys;
    private Vector2 _velocity;
    private CollisionDetector _collisionDetector;
    
    void Awake()
    {
        _phys = GetComponent<Rigidbody2D>();
        _collisionDetector = GetComponent<CollisionDetector>();
    }
    
    void Start()
    {
        _acceleration = 0;
    }

    void Update(){
        
        // Deteccion de las teclas de movimiento y validación de ambas teclas presionadas
        moveDetector =  (Input.GetKey(KeyCode.D) ^ Input.GetKey(KeyCode.A)) ? 
                            (Input.GetKey(KeyCode.D) ? 
                                1: 
                            (Input.GetKey(KeyCode.A) ? 
                                -1 : 
                            0)) : 0;

        // Deteccion de la tecla para correr
        _maxSpeed = Input.GetKey(KeyCode.LeftShift) ? 15f : 10f;

        // Coeficiente de friccion
        _friction = _collisionDetector.objectCollTag switch
        {
            "Terrain" => terrainFriction,
            "Air" => 0.1f,
            _ => 0f,
        };

        if (!_isJumping)
            _isJumping = !_collisionDetector.onGround;

    }

    void FixedUpdate()
    {
        _velocity.y = _phys.velocity.y;
        if(_collisionDetector.onGround && _isJumping){
            _isJumping = false;
            StartCoroutine(AditionalMoveForce());
        }

        print("Move force: " + _moveForce);

        // Se acelera con un tope de velocidad en 10 o -10 (En teoría no debería afectar el sistema de fisicas de unity a 
        // esta parte del movimiento)
        if (moveDetector != 0 && _collisionDetector.onGround) {
            _acceleration += (Mathf.Sign(moveDetector) * _moveForce - Mathf.Sign(moveDetector) * _friction) * Time.deltaTime;
            _acceleration = Mathf.Clamp(_acceleration, -_maxSpeed, _maxSpeed);
        } else if (_acceleration != 0f) {
            float deceleration = (-1) * Mathf.Sign(_acceleration) * _friction * Time.deltaTime * _weight;
            _acceleration = Mathf.Sign(_acceleration) == 1 ? 
                (_acceleration + deceleration > 0.9 ? _acceleration + deceleration : 0) : 
                (_acceleration + deceleration < -0.9 ? _acceleration + deceleration : 0);
            // print(deceleration);
        }

        _velocity.x = _acceleration;
        _phys.velocity = _velocity;
        // print(acceleration);
    }

    IEnumerator AditionalMoveForce()
    {
        float originalVal = _moveForce;
        _moveForce *= 4;
        yield return new WaitForFixedUpdate();
        _moveForce = originalVal;
    }

}
