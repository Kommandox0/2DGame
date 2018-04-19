using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollisions : MonoBehaviour
{
    public Collider2D collider2D;
    public ContactFilter2D contactFilter;
    public Collider2D[] results;
    public int numCollider;

    public Vector2 boxSize;

	private void FixedUpdate ()
    {
        numCollider = Physics2D.OverlapBox(this.transform.position, boxSize, 0, contactFilter, results);
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(this.transform.position, boxSize);
    }
}
