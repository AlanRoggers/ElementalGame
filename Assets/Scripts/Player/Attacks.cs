using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public bool attack1;
    private CollisionDetector _collisionDetector;

    void Awake()
    {
        _collisionDetector = GetComponent<CollisionDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !attack1){
            attack1 = true;
            if (_collisionDetector.kicking)
                print("Kick");
        }
        else if (attack1)
            attack1 = false;
    }
}
