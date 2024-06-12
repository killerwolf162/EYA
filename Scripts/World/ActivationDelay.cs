using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActivationDelay : MonoBehaviour
{

    private Button button;
    private TextMeshProUGUI text;
    private Image image;
    public int time_to_wait = 3;
    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        text = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        
    }
    void Start()
    {
        image.enabled = false;
        button.enabled = false;
        text.enabled = false;
        StartCoroutine(wait());
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(time_to_wait);
        image.enabled = true;
        button.enabled = true;
        text.enabled = true;
        StopAllCoroutines();
    }

}
