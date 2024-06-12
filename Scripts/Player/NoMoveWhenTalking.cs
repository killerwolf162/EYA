using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMoveWhenTalking : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject textBackground;

    private void Update()
    {
        textBackground = GameObject.FindGameObjectWithTag("TextBackground");
        if(textBackground == null)
        {
            this.GetComponent<PlayerMovement>().enabled = true;
        }
        else if(textBackground != null)
        {
            this.GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
