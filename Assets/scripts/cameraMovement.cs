using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Camera fpsCamera; // Referencia a la cámara en primera persona

    public float horizontalSpeed; // Velocidad de rotación horizontal
    public float verticalSpeed; // Velocidad de rotación vertical

    private float h; // Movimiento horizontal del mouse
    private float v; // Movimiento vertical del mouse

    // Start is called before the first frame update
    void Start()
    {
        // No se realiza ninguna acción al inicio
    }

    public void para()
    {
        horizontalSpeed = 0.0f; // Establece la velocidad horizontal a cero
        verticalSpeed = 0.0f; // Establece la velocidad vertical a cero
    }

    // Update is called once per frame
    void Update()
    {
        h = horizontalSpeed * Input.GetAxis("Mouse X"); // Obtiene el movimiento horizontal del mouse multiplicado por la velocidad horizontal
        v = verticalSpeed * Input.GetAxis("Mouse Y"); // Obtiene el movimiento vertical del mouse multiplicado por la velocidad vertical

        // Limitar la rotación vertical para evitar mirar hacia atrás
        float currentRotationX = fpsCamera.transform.eulerAngles.x; // Obtiene la rotación actual en el eje X de la cámara en primera persona
        float newRotationX = currentRotationX - v; // Calcula la nueva rotación en el eje X restando el movimiento vertical
        if (newRotationX > 180f)
        {
            newRotationX -= 360f; // Si la nueva rotación es mayor a 180 grados, se le resta 360 grados para mantenerla dentro del rango [-180, 180]
        }
        newRotationX = Mathf.Clamp(newRotationX, -80f, 80f); // Limita la rotación en el eje X para evitar mirar demasiado hacia arriba o hacia abajo

        // Limitar la rotación horizontal
        float currentRotationY = transform.eulerAngles.y; // Obtiene la rotación actual en el eje Y del objeto
        float newRotationY = currentRotationY + h; // Calcula la nueva rotación en el eje Y sumando el movimiento horizontal

        transform.rotation = Quaternion.Euler(0, newRotationY, 0); // Actualiza la rotación del objeto en base a la nueva rotación en el eje Y
        fpsCamera.transform.localRotation = Quaternion.Euler(newRotationX, 0, 0); // Actualiza la rotación local de la cámara en primera persona en base a la nueva rotación en el eje X
    }
}
