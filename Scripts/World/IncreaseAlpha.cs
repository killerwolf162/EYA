using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseAlpha : MonoBehaviour
{
    public Color newColor = Color.black;
    public Image transition_image;
    private SceneSwapper sceneSwapper;

    private void Start()
    {
        newColor.a = 0;
    }
    public void increase_Alpha()
    {
        StartCoroutine(increaseAlpha());
    }

    public IEnumerator increaseAlpha()
    {
        while (newColor.a < 1)
        {
            newColor.a += 0.005f;
            transition_image.color = newColor;
            yield return new WaitForSeconds(0.01f);
        }

        if (newColor.a >= 1)
        {
            yield return new WaitForSeconds(1);
            StopAllCoroutines();
        }
        yield return null;
    }
}
