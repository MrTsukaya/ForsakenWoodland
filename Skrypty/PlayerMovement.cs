using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Ustawienia Gracza")]
    [SerializeField] private float speed;

    private Rigidbody rigidbody;
    private Animator animator;

    private bool facingRight = true;
    private float hDirection;
    private float vDirection;

    private Vector3 moveH = new Vector3(0, 0, 0);
    private Vector3 moveV = new Vector3(0, 0, 0);

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        hDirection = Input.GetAxis("Horizontal") * speed;
        vDirection = Input.GetAxis("Vertical") * speed;

        if(hDirection !=0 || vDirection != 0)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }
    private void FixedUpdate()
    {     

        if(hDirection != 0)
        {
            MoveH(hDirection * Time.fixedDeltaTime);
        }
        if (vDirection != 0)
        {
            MoveV(vDirection * Time.fixedDeltaTime);
        }

    }
    private void MoveH(float move)
    {
        rigidbody.velocity = new Vector3(move, 0, rigidbody.velocity.z);
        if(move > 0 && !facingRight)
        {
            Flip();
        }
        else if(move < 0 && facingRight)
        {
            Flip();
        }
    }
    private void MoveV(float move)
    {
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, move);
    }
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

}
