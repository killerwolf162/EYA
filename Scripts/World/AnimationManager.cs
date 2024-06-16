using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AnimationManager : MonoBehaviour
{
    public UnityEvent everyoneCrouch;
    private Color color;
    public Image image;
    public AudioSource audioSource;

    private void Start()
    {
        everyoneCrouch.Invoke();
    }

    private void Update()
    {
        if(image.color.a >= 1)
        {
            audioSource.enabled = true;
        }
    }


}