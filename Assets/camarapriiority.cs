using Unity.Cinemachine;
using UnityEngine;

public class camarapriiority : MonoBehaviour
{
    public CinemachineVirtualCamera currentCamera;
    void Start()
    {
        currentCamera.Priority++;
    }
    public void UpdateCamera(CinemachineVirtualCamera target)
    {
        currentCamera.Priority--;
        currentCamera = target;
        currentCamera.Priority++;
        currentCamera.Priority++;
    }
}
