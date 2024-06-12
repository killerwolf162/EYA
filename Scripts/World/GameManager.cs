using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public UnityEvent Camera_Transition, Problem_Intro_Walk, Problem_Walk, Questioning_Setup;
    public Image transition_image;
    public Color newColor = Color.clear;
    public GameObject Intro_Area, Problem_Intro, Problem_Area, Problem_Area_2;
    public List<Camera> cameras = new List<Camera>();
    public List<GameObject> scenes = new List<GameObject>();

    private void Start()
    {
        cameras.AddRange(GameObject.FindObjectsOfType<Camera>());
        cameras = cameras.OrderBy(o => o.name).ToList();

        scenes.Add(Intro_Area); scenes.Add(Problem_Area); scenes.Add(Problem_Area); scenes.Add(Problem_Area_2);

        foreach (Camera camera in cameras)
        {
            camera.enabled = false;
        }
        cameras[0].enabled = true;
        transition_image.enabled = false;
    }

    public void StartCameraTransition()
    {
        StartCoroutine(IncreaseAlpha());
    }
    public IEnumerator IncreaseAlpha()
    {
        while (newColor.a < 1)
        {
            newColor.a += 0.005f;
            transition_image.color = newColor;
            yield return new WaitForSeconds(0.01f);
        }
       
        if(newColor.a >= 1)
        {
            yield return new WaitForSeconds(1);
            StopAllCoroutines();
            SwapScene();
            StartCoroutine(DecreaseAlpha());
        }
        yield return null;
    }

    public IEnumerator DecreaseAlpha()
    {
        while (newColor.a > 0)
        {
            newColor.a -= 0.005f;
            transition_image.color = newColor;
            yield return new WaitForSeconds(0.02f);
        }
        if (newColor.a <= 0)
        {
            transition_image.enabled = false;
            StopAllCoroutines();
        }

        yield return null;
    }

    public void StartQuestioningTransition()
    {
        StartCoroutine(Transition_to_Questioning());
    }

    private IEnumerator Transition_to_Questioning()
    {
        transition_image.enabled = true;
        Camera_Transition.Invoke();
        yield return new WaitForSeconds(3);
        Questioning_Setup.Invoke();
        cameras.AddRange(GameObject.FindObjectsOfType<Camera>());
        cameras = cameras.OrderBy(o => o.name).ToList();
        StopCoroutine(Transition_to_Questioning());
    }

    private void SwapScene()
    {
        cameras[0].GetComponentInParent<AudioListener>().enabled = false;
        Destroy(cameras[0]);
        //cameras[0].enabled = false;
        cameras.Remove(cameras[0]);
        scenes.Remove(scenes[0]);
        cameras[0].enabled = true;
        cameras[0].GetComponentInParent<AudioListener>().enabled = true;
    }

}
