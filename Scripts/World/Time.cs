using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time : MonoBehaviour
{
    internal static int timeScale;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    public void start_time()
    {
        Time.timeScale = 1;
    }
}
