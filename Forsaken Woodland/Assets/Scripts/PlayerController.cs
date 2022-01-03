using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Ustawienia Gracza")]
    [SerializeField] private float speed;

    private Rigidbody rb;
    private Animator animator;
    Vector3 movement;

    //strzelanie
    public Transform crossbow;
    public GameObject bolt;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); 
    }
    private void Update()
    {
        //ruszanie si�
        //pobiera inputy (WSAD i strza�ki, warto�ci mi�dzy -1 i 1 )
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        //normalizacja �eby na ukos nie mia� speeda 40% szybciej
        movement = movement.normalized;

        //przesy�a dane do animatora kt�re wykorzystamy w blend tree idle
        if(movement.x != 0 || movement.z != 0)
        {
            animator.SetFloat("LastHorizontal", movement.x);
            animator.SetFloat("LastVertical", movement.z);           
        }
        //przesy�a dane do animatora kt�re wykorzystamy w blend tree Movement
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.z);



        //prosty if do przej�cia z chodzenia na idle etc
        if(movement.x != 0 || movement.z != 0)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        //strzelanie
        //obraca "kusz�" w kierunku chodu
        if(movement.x > 0)
        {
            crossbow.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (movement.x < 0)
        {
            crossbow.localRotation = Quaternion.Euler(0, 0, 180);
        }
        if (movement.z > 0)
        {
            crossbow.localRotation = Quaternion.Euler(0, -90, 0);
        }
        if (movement.z < 0)
        {
            crossbow.localRotation = Quaternion.Euler(0, 90, 0);
        }


        //wystrza�
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    private void FixedUpdate()
    {
        //ruszamy si� xD
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
    private void Shoot()
    {
        Instantiate(bolt, crossbow.position, crossbow.rotation);
    }
    
   
}
