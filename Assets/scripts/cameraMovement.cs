using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Camera fpsCamera;

    public float horizontalSpeed;
    public float verticalSpeed;

    private float h;
    private float v;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void para()
    {
        horizontalSpeed = 0.0f;
        verticalSpeed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        h = horizontalSpeed * Input.GetAxis("Mouse X");
        v = verticalSpeed * Input.GetAxis("Mouse Y");

        // Limitar la rotación vertical para evitar mirar hacia atrás
        float currentRotationX = fpsCamera.transform.eulerAngles.x;
        float newRotationX = currentRotationX - v;
        if (newRotationX > 180f)
        {
            newRotationX -= 360f;
        }
        newRotationX = Mathf.Clamp(newRotationX, -80f, 80f);

        // Limitar la rotación horizontal
        float currentRotationY = transform.eulerAngles.y;
        float newRotationY = currentRotationY + h;

        transform.rotation = Quaternion.Euler(0, newRotationY, 0);
        fpsCamera.transform.localRotation = Quaternion.Euler(newRotationX, 0, 0);
    }
}
