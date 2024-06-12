using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Transform player;
    public float sensitivity = 2f;
    float cameraVecticalRotation = 0f;
    [SerializeField]
    public float minClamp, maxClamp;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        //player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * sensitivity;
        float inputY = Input.GetAxis("Mouse Y") * sensitivity;

        cameraVecticalRotation -= inputY;
        cameraVecticalRotation = Mathf.Clamp(cameraVecticalRotation, minClamp, maxClamp);
        transform.localEulerAngles = Vector3.right * cameraVecticalRotation;

        player.Rotate(Vector3.up * inputX);
    }
}
