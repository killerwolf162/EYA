using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable {

    [SerializeField] private string interactText;
    [SerializeField] private TalkEventManager talkManager;

    private void Awake()
    {
        talkManager = GameObject.FindObjectOfType<TalkEventManager>();
    }
    public void Interact() {

        //animator.SetTrigger("Talk");

        if(this.CompareTag("Karloman") == true)
        {
            talkManager.talkWithKarloman.Invoke();
        }
        else if (this.CompareTag("Johanson") == true)
        {
            talkManager.talkWithJohanson.Invoke();
        }
        else if (this.CompareTag("Bernard") == true)
        {
            talkManager.talkWithBernard.Invoke();
        }
        else if (this.CompareTag("Joachim") == true)
        {
            talkManager.talkWithJoachim.Invoke();
        }
        else if (this.CompareTag("MillersDaughter") == true)
        {
            talkManager.talkWithMillersDaughter.Invoke();
        }
        else if (this.CompareTag("Harold") == true)
        {
            talkManager.talkWithHarold.Invoke();
        }
        else
        {
            Debug.Log("not the tag");
        }
    }

    public string GetInteractText() {
        return interactText;
    }

    public Transform GetTransform() {
        return transform;
    }

}