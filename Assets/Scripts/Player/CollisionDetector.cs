using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public bool kicking;
    public bool onGround;
    public string objectCollTag;
    [SerializeField] private LayerMask _terrain;
    [SerializeField] private LayerMask _enemy;
    [SerializeField] private BoxCollider2D _feetBox;
    [SerializeField] private BoxCollider2D _headBox;
    [SerializeField] private Vector2 _feetFix;
    [SerializeField] private Vector2 _kickPosFix;
    [SerializeField] private Vector2 _kickSizeFix;

    void Update()
    {
        Collider2D floorDetector = Physics2D.OverlapBox(_feetBox.bounds.center, _feetBox.size + _feetFix, 0f, _terrain);
        onGround = floorDetector != null;
        objectCollTag = onGround ? floorDetector.gameObject.tag : "Air";
        Collider2D kickDetector = Physics2D.OverlapBox((Vector2) transform.localPosition + _kickPosFix, _kickSizeFix, 0f, _enemy);
        kicking = kickDetector != null;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = onGround ? Color.green : Color.red;
        Gizmos.DrawWireCube(_feetBox.bounds.center, _feetBox.size + _feetFix);
        Gizmos.color = kicking ? Color.green : Color.yellow;
        Gizmos.DrawWireCube((Vector2) transform.localPosition + _kickPosFix, _kickSizeFix);
    }
}
