using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Karloman : MonoBehaviour
{
    Animator anim;
    GameManager game_manager;
    public NavMeshAgent agent;
    [SerializeField]

    public GameObject waypoint;
    private Vector3 target_pos;

    private void Awake()
    {
        game_manager = FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        anim.SetBool("Pacifist", true);
        anim.SetInteger("WeaponType_int", 0);
    }

    private void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Camera_1_transition")
        {
            StartCoroutine(transition_to_new_area_1());
        }
        if (other.tag == "Waypoint")
        {
            anim.SetBool("Static_b", true);
            anim.SetFloat("Speed_f", 0f);
        }
    }

    public void to_problem_area()
    {
        StartCoroutine(transition_to_new_area_2());
    }

    public void crouch()
    {
        anim.SetBool("Crouch_b", true);
    }

    public void stand_up()
    {
        anim.SetBool("Crouch_b", false);
    }

    public void move_to_waypoint()
    {
        target_pos = waypoint.transform.position;
        anim.SetBool("Static_b", false);
        anim.SetFloat("Speed_f", 0.3f);
        agent.SetDestination(target_pos);
    }

    private IEnumerator transition_to_new_area_1()
    {
        game_manager.transition_image.enabled = true;
        game_manager.Camera_Transition.Invoke();
        yield return new WaitForSeconds(3);
        game_manager.Problem_Intro_Walk.Invoke();       
        StopCoroutine(transition_to_new_area_1());
    }

    public IEnumerator transition_to_new_area_2()
    {
        game_manager.transition_image.enabled = true;
        game_manager.Camera_Transition.Invoke();
        yield return new WaitForSeconds(3);
        game_manager.Problem_Walk.Invoke();
        StopCoroutine(transition_to_new_area_2());
    }

}
