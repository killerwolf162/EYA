using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class BasicNPC : MonoBehaviour
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
        if (other.tag == "Waypoint")
        {
            anim.SetBool("Static_b", true);
            anim.SetFloat("Speed_f", 0f);
        }
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
}
