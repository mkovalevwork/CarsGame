using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public Vector3 spawnPosition;                                             //player spawn position
    public GameObject mainCamera;                                             //mainCamera gameobject

    private void Start()
    {
        MenuManager._chosenCar.transform.position = spawnPosition;                 //setPosition
        MenuManager._chosenCar.transform.rotation = Quaternion.Euler(0, 0, 0);     //setRotation
        MenuManager._chosenCar.AddComponent<PlayerController>();                   //addController
        mainCamera.transform.SetParent(MenuManager._chosenCar.transform);          //cameraSetAsChild to player
    }
}
