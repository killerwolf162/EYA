using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecreaseAlpha : MonoBehaviour
{
    public Color newColor = Color.black;
    public Image transition_image;
    public IEnumerator decreaseAlpha()
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
            Destroy(this);
            StopAllCoroutines();
        }

        yield return null;
    }

    private void Start()
    {
        StartCoroutine(decreaseAlpha());
    }
}
