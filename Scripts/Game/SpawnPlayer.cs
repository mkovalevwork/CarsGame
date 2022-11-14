using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public Vector3 spawnPosition;                                             //player spawn position
    public GameObject mainCamera;                                             //mainCamera gameobject

    void Start()
    {
        SaveActualCar.car.transform.position = spawnPosition;                 //setPosition
        SaveActualCar.car.transform.rotation = Quaternion.Euler(0, 0, 0);     //setRotation
        SaveActualCar.car.AddComponent<PlayerController>();                   //addController
        mainCamera.transform.SetParent(SaveActualCar.car.transform);          //cameraSetAsChild to player
    }
}
