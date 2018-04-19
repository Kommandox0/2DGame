using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    [Header("State")]
    [Header("Ground")]
    public bool isGrounded;
    public bool wasGroundedLastFrame;
    public bool justGotGrounded;
    public bool justNotGrounded;
    public bool isFalling;
    [Header("Wall")]
    public bool isWalled;
    public bool wasWalledLastFrame;
    public bool justGotWalled;
    public bool justNotWalled;
    [Header("Ceiling")]
    public bool isCeiling;
    public bool wasCeilingLastFrame;
    public bool justGotCeiling;
    public bool justNotCeiling;

    [Header("Filter")]
    public ContactFilter2D filter;
    public ContactFilter2D wallFilter;
    public ContactFilter2D ceilingFilter;
    public int maxColliders = 1;
    public bool checkGround = true;
    public bool checkWall = true;
    public bool checkCeiling = true;

    [Header("BoxProperties")]
    public Vector2 groundBoxPos;
    public Vector2 groundBoxSize;
    public Vector2 wallBoxPos;
    public Vector2 wallBoxSize;
    public Vector2 ceilingBoxPos;
    public Vector2 ceilingBoxSize;

    private void FixedUpdate()
    {
        ResetState();
        GroundDetection();
        WallDetection();
        CeilingDetection();
    }

    void ResetState()
    {
        wasGroundedLastFrame = isGrounded;
        isFalling = !isGrounded;

        isGrounded = false;
        justNotGrounded = false;
        justGotGrounded = false;

        wasWalledLastFrame = isWalled;

        isWalled = false;
        justNotWalled = false;
        justGotWalled = false;

        wasCeilingLastFrame = isCeiling;

        isCeiling = false;
        justNotCeiling = false;
        justGotCeiling = false;
    }

    void GroundDetection()
    {
        if(!checkGround) return;

        Vector3 pos = this.transform.position + (Vector3)groundBoxPos;
        Collider2D[] results = new Collider2D[maxColliders];

        int numColliders = Physics2D.OverlapBox(pos, groundBoxSize, 0, filter, results);

        if(numColliders > 0)
        {
            isGrounded = true;
        }

        if(!wasGroundedLastFrame && isGrounded) justGotGrounded = true;
        if(wasGroundedLastFrame && !isGrounded) justNotGrounded = true;

        if(justNotGrounded) Debug.Log("JUST NOT GROUNDED");
        if(justGotGrounded) Debug.Log("just got grounded");
    }

    void WallDetection()
    {
        if (!checkWall) return;

        Vector3 pos = this.transform.position + (Vector3)wallBoxPos;
        Collider2D[] results = new Collider2D[maxColliders];

        int numColliders = Physics2D.OverlapBox(pos, wallBoxSize, 0, wallFilter, results);

        if (numColliders > 0)
        {
            isWalled = true;
        }

        if (!wasWalledLastFrame && isWalled) justGotWalled = true;
        if (wasWalledLastFrame && !isWalled) justNotWalled = true;

        if (justNotWalled) Debug.Log("JUST NOT WALLED");
        if (justGotWalled) Debug.Log("just got walled");
    }

    void CeilingDetection()
    {
        if (!checkCeiling) return;

        Vector3 pos = this.transform.position + (Vector3)ceilingBoxPos;
        Collider2D[] results = new Collider2D[maxColliders];

        int numColliders = Physics2D.OverlapBox(pos, ceilingBoxSize, 0, ceilingFilter, results);

        if (numColliders > 0)
        {
            isCeiling = true;
        }

        if (!wasCeilingLastFrame && isCeiling) justGotCeiling = true;
        if (wasCeilingLastFrame && !isCeiling) justNotCeiling = true;

        if (justNotCeiling) Debug.Log("JUST NOT CEILING");
        if (justGotCeiling) Debug.Log("just got ceiling");
    }

    private void OnDrawGizmosSelected()
    {
        //GROUND
        Gizmos.color = Color.yellow;
        Vector3 pos = this.transform.position + (Vector3)groundBoxPos;
        Gizmos.DrawWireCube(pos, groundBoxSize);

        //WALL
        Gizmos.color = Color.blue;
        Vector3 poswall = this.transform.position + (Vector3)wallBoxPos;
        Gizmos.DrawWireCube(poswall, wallBoxSize);

        //CEILING
        Gizmos.color = Color.red;
        Vector3 posceiling = this.transform.position + (Vector3)ceilingBoxPos;
        Gizmos.DrawWireCube(posceiling, ceilingBoxSize);
    }
}
