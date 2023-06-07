using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public bool onGround;
    public string objectCollTag;
    [SerializeField] LayerMask terrain;
    [SerializeField] private BoxCollider2D _feetBox;
    [SerializeField] private BoxCollider2D _headBox;
    [SerializeField] private Vector2 _auxiliar;

    // Update is called once per frame
    void Update()
    {
        Collider2D floorDetector = Physics2D.OverlapBox(_feetBox.bounds.center, _feetBox.size + _auxiliar, 0f, terrain);
        onGround = floorDetector != null;
        objectCollTag = onGround ? floorDetector.gameObject.tag : "Air";
    }

    void OnDrawGizmos()
    {
        Gizmos.color = onGround ? Color.green : Color.red;
        Gizmos.DrawWireCube(_feetBox.bounds.center, _feetBox.size + _auxiliar);
    }
}
