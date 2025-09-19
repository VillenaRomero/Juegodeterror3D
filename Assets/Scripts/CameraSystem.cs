using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [Header("Cámaras de seguridad")]
    public Camera[] securityCameras; 
    private int currentCameraIndex = 0;

    [Header("Jugador")]
    public Camera playerCamera; 
    private Vector3 savedPosition;
    private Quaternion savedRotation;

    private bool inSecurityMode = false;

    void Start()
    {
        EnablePlayerCamera();
    }

    void Update()
    {
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

        if (inSecurityMode && Input.GetKeyDown(KeyCode.E))
        {
            SwitchToNextCamera();
        }
    }

    void EnterSecurityMode()
    {
        inSecurityMode = true;

        savedPosition = playerCamera.transform.position;
        savedRotation = playerCamera.transform.rotation;

        playerCamera.enabled = false;

        currentCameraIndex = 0;
        EnableOnlyCamera(securityCameras[currentCameraIndex]);
    }

    void ExitSecurityMode()
    {
        inSecurityMode = false;

        for (int i = 0; i < securityCameras.Length; i++)
        {
            securityCameras[i].enabled = false;
        }

        playerCamera.enabled = true;
        playerCamera.transform.position = savedPosition;
        playerCamera.transform.rotation = savedRotation;
    }

    void SwitchToNextCamera()
    {
        securityCameras[currentCameraIndex].enabled = false;

        currentCameraIndex++;
        if (currentCameraIndex >= securityCameras.Length)
        {
            currentCameraIndex = 0; 
        }

        EnableOnlyCamera(securityCameras[currentCameraIndex]);
    }

    void EnableOnlyCamera(Camera cam)
    {
        for (int i = 0; i < securityCameras.Length; i++)
        {
            securityCameras[i].enabled = false;
        }
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
