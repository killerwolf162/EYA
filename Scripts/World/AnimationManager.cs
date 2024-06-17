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
    private SceneSwapper sceneSwapper;

    private void Start()
    {
        sceneSwapper = GameObject.FindObjectOfType<SceneSwapper>();
        everyoneCrouch.Invoke();
    }

    private void Update()
    {
        if(image.color.a >= 1)
        {
            audioSource.enabled = true;
            loadEndScene();
        }
    }

    private void loadEndScene()
    {
        StartCoroutine(waitBeforeEndScene());
    }

    private IEnumerator waitBeforeEndScene()
    {
        yield return new WaitForSeconds(3);
        sceneSwapper.loadEndArea();

    }

}