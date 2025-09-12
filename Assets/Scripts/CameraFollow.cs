using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;   // Referencia al jugador
    public float sensitivity = 200f; // Velocidad de giro
    public float distance = 5f; // Distancia detrás del jugador
    public float height = 2f;   // Altura de la cámara

    private float currentYaw = 0f; // Rotación acumulada

    void LateUpdate()
    {
        // Rotación izquierda/derecha con el mouse
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        currentYaw += mouseX;

        // Posición de la cámara alrededor del jugador
        Vector3 offset = Quaternion.Euler(0f, currentYaw, 0f) * Vector3.back * distance;
        Vector3 targetPos = player.position + Vector3.up * height + offset;

        transform.position = targetPos;

        // La cámara mira al jugador
        transform.LookAt(player.position + Vector3.up * height * 0.5f);
    }
}
