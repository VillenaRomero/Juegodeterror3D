using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [Header("C�maras de seguridad")]
    public Camera[] securityCameras; // C�maras de seguridad
    private int currentCameraIndex = 0;

    [Header("Jugador")]
    public Camera playerCamera; // C�mara en primera persona
    private Vector3 savedPosition;
    private Quaternion savedRotation;

    private bool inSecurityMode = false;

    void Start()
    {
        // Activar solo la c�mara del jugador al inicio
        EnablePlayerCamera();
    }

    void Update()
    {
        // Tab = entrar o salir de c�maras
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!inSecurityMode)
            {
                EnterSecurityMode();
            }
            else
            {
                ExitSecurityMode();
            }
        }

        // E = cambiar de c�mara
        if (inSecurityMode && Input.GetKeyDown(KeyCode.E))
        {
            SwitchToNextCamera();
        }
    }

    void EnterSecurityMode()
    {
        inSecurityMode = true;

        // Guardar posici�n y rotaci�n del jugador
        savedPosition = playerCamera.transform.position;
        savedRotation = playerCamera.transform.rotation;

        // Desactivar c�mara del jugador
        playerCamera.enabled = false;

        // Activar la primera c�mara de seguridad
        currentCameraIndex = 0;
        EnableOnlyCamera(securityCameras[currentCameraIndex]);
    }

    void ExitSecurityMode()
    {
        inSecurityMode = false;

        // Desactivar todas las c�maras de seguridad
        for (int i = 0; i < securityCameras.Length; i++)
        {
            securityCameras[i].enabled = false;
        }

        // Volver a la c�mara del jugador
        playerCamera.enabled = true;
        playerCamera.transform.position = savedPosition;
        playerCamera.transform.rotation = savedRotation;
    }

    void SwitchToNextCamera()
    {
        // Desactivar la c�mara actual
        securityCameras[currentCameraIndex].enabled = false;

        // Pasar a la siguiente
        currentCameraIndex++;
        if (currentCameraIndex >= securityCameras.Length)
        {
            currentCameraIndex = 0; // Volver a la primera
        }

        // Activar la nueva
        EnableOnlyCamera(securityCameras[currentCameraIndex]);
    }

    void EnableOnlyCamera(Camera cam)
    {
        // Desactivar todas
        for (int i = 0; i < securityCameras.Length; i++)
        {
            securityCameras[i].enabled = false;
        }
        // Activar la indicada
        cam.enabled = true;
    }

    void EnablePlayerCamera()
    {
        playerCamera.enabled = true;
        for (int i = 0; i < securityCameras.Length; i++)
        {
            securityCameras[i].enabled = false;
        }
    }
}
