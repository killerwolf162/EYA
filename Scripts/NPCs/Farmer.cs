using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class Farmer : MonoBehaviour
{

    [SerializeField]
    UnityEvent First_Petition, In_Position;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {

        anim.SetBool("Pacifist", true);
        anim.SetInteger("WeaponType_int", 0);
    }

    public void in_position()
    {
        StopCoroutine(start_moving());
        anim.SetBool("Static_b", true);
        anim.SetFloat("Speed_f", 0);
        crouch();
        StartCoroutine(wait());
    }

    public void crouch()
    {
        anim.SetBool("Crouch_b", true);
    }

    public void stand_up()
    {
        anim.SetBool("Crouch_b", false);
    }

    public void move()
    {
        anim.SetBool("Static_b", false);
        anim.SetFloat("Speed_f", 0.3f);
        start_moving();
    }

    public void salute()
    {
        StartCoroutine(Salute());
    }

    public void idle()
    {
        anim.SetInteger("Animation_int", 0);
    }

    public IEnumerator start_moving()
    {
        this.transform.position += new Vector3(0.2f, 0, 0);
        yield return new WaitForSeconds(1);

    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(2);

        First_Petition.Invoke();
        StopCoroutine(wait());
    }

    public IEnumerator Salute()
    {
        salute();
        anim.SetInteger("Animation_int", 6);
        yield return new WaitForSeconds(2);
        idle();
        StopCoroutine(Salute());
    }



    private void OnTriggerEnter(Collider other)
    {
        In_Position.Invoke();
    }

}
