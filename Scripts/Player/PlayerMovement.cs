
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Animator anim;
    private Rigidbody rig;


    [SerializeField]
    private int walk_speed, sprint_speed;
    private Vector3 movementDirection;
    public float rotation_speed;

    private GameObject textBackgroud;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        //anim.SetBool("Pacifist", true);
        Move();
    }

    public void Move()
    {
        rig.transform.Translate(movementDirection * Time.deltaTime * walk_speed);
        if(movementDirection != Vector3.zero)
        {
            Quaternion to_rotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, to_rotation, rotation_speed*Time.deltaTime);
        }
    }

    public void OnMove(InputAction.CallbackContext input_value)
    {
        Vector2 movement = input_value.ReadValue<Vector2>();
        movementDirection = new Vector3(movement.x, 0, movement.y);
        movementDirection.Normalize();
    }

}
