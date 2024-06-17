using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwapper : MonoBehaviour
{
    public Color newColor = Color.black;
    public Image transition_image;

    private void Start()
    {
        newColor.a = 0;
    }

    public void loadMainArea()
    {
        SceneManager.LoadScene("Main_Scene");
    }

    public void loadEndArea()
    {
        SceneManager.LoadScene("EndScene");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void loadExecution()
    {
        StartCoroutine(ExecutionTransition());
    }
    public void loadFine()
    {
        StartCoroutine(FineTransition());
    }
    public void loadFreeToGo()
    {
        StartCoroutine(FreeToGOTransition());
    }

    private IEnumerator ExecutionTransition()
    {
        transition_image.enabled = true;
        while (newColor.a < 1)
        {
            Debug.Log(newColor.a);
            newColor.a += 0.005f;
            transition_image.color = newColor;
            yield return new WaitForSeconds(0.01f);
        }

        if (newColor.a >= 1)
        {
            Debug.Log(newColor.a);
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("ExecutionScene");
            StopAllCoroutines();
        }
        yield return null;
    }
    private IEnumerator FineTransition()
    {
        transition_image.enabled = true;
        while (newColor.a < 1)
        {
            newColor.a += 0.005f;
            transition_image.color = newColor;
            yield return new WaitForSeconds(0.01f);
        }

        if (newColor.a >= 1)
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("FineScene");
            StopAllCoroutines();
        }
        yield return null;
    }
    private IEnumerator FreeToGOTransition()
    {
        transition_image.enabled = true;
        while (newColor.a < 1)
        {
            newColor.a += 0.005f;
            transition_image.color = newColor;
            yield return new WaitForSeconds(0.01f);
        }

        if (newColor.a >= 1)
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("FreeToGoScene");
            StopAllCoroutines();
        }
        yield return null;
    }

}
