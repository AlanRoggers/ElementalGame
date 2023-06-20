using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public bool onGround;
    private bool _movingStartPoint;
    [SerializeField] private Vector2 _startPoint;
    [SerializeField] private Vector2 _size;
    [SerializeField] private LayerMask _terrain;

    void Start()
    {
        _movingStartPoint = false;
    }

    void Update()
    {
        Collider2D floorDetector = Physics2D.OverlapBox((Vector2) transform.localPosition + _startPoint, _size, 0f, _terrain);
        onGround = floorDetector != null;
        if(!onGround && !_movingStartPoint) {
            transform.localScale = new Vector3 (-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
            _startPoint = new Vector2(_startPoint.x * -1, _startPoint.y);
            StartCoroutine(ChangeDetectorPosition());
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = onGround ? Color.green : Color.red;
        Gizmos.DrawWireCube((Vector2) transform.localPosition + _startPoint, _size);
    }

    IEnumerator ChangeDetectorPosition()
    {
        _movingStartPoint = true;
        yield return new WaitForSeconds(1f);
        _movingStartPoint = false;
    }
}
