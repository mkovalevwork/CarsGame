using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _mainCamera;
    public List<Transform> camerasPositions = new List<Transform>(); //5pos for main menu position

    public void ChangeCamera(int cameraIndex)
    {
        _mainCamera.transform.position = camerasPositions[cameraIndex].position;
        _mainCamera.transform.eulerAngles = camerasPositions[cameraIndex].eulerAngles;
    }
}
