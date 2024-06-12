using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player, spawnPlace;

    public void spawnPlayer()
    {
        Instantiate(player, spawnPlace.transform.position, spawnPlace.transform.rotation);
    }
}
