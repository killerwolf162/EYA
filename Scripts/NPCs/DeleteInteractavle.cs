using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteInteractavle : MonoBehaviour
{


    private NPCInteractable npcInteract;

    private void Awake()
    {
        npcInteract = GetComponent<NPCInteractable>();
    }
    public void deleteInteract()
    {
        Destroy(npcInteract);
    }

}
