using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComtroller : MonoBehaviour
{
    public bool isJumping;
    public float moveSpeed;
    public float jumpForce;
    Transform tr;
    Rigidbody2D rb;
    public Transform groundDetectPoint;
    public float groundMinDistanse;
    Physics2D.Box

    private void Awake()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
 
        rb.position += new Vector2(h * moveSpeed * Time.deltaTime, 0);
        if ( Input.GetKeyDown(KeyCode.LeftAlt) && isJumping == false )
        {
            isJumping = true;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }

        Vector2 origin = groundDetectPoint.position;
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, groundMinDistanse);
        Collider2D hitCol = hit.collider;
        if( hitCol != null )
        {
            if(hitCol.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                isJumping=false;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(groundDetectPoint.position,
                        new Vector3(groundDetectPoint.position.x,
                                    groundDetectPoint.position.y - groundMinDistanse,
                                    groundDetectPoint.position.z));
    }

}
