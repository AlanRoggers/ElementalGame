using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateF : MonoBehaviour
{
    private Rigidbody2D _phys;
    private Animator _anim;
    // Start is called before the first frame update
    void Awake()
    {
        _anim = GetComponent<Animator>();
        _phys = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _anim.SetBool("Moving", _phys.velocity.x != 0);
    }
}
