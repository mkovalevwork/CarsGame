using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject chosenCar;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private UIManager UIManager;
    [SerializeField] private GameObject[] cars;
    private int carIndex = 0;
    [SerializeField] private Transform[] camerasPositions; //5pos for main menu position


    public Image loadingProgressBar;

    List<AsyncOperation> scenesToLoad = new List<AsyncOperation> ();
    public void StartButton()
    {
        
        if (chosenCar != null)
        {
            SaveActualCar.car.AddComponent<DontDestroyOnLoad>();
            UIManager.mainCanvas.SetActive(false);
            UIManager.chooseCarCanvas.SetActive(false);
            UIManager.LoadingBarCanvas.SetActive(true);
            scenesToLoad.Add(SceneManager.LoadSceneAsync(1));
            StartCoroutine("LoadingScreen");           
        }
    }

    //StartManuChoseButton
    public void ChoseCarButton()
    {
        mainCamera.transform.position = camerasPositions[carIndex].position;
        mainCamera.transform.eulerAngles = camerasPositions[carIndex].eulerAngles;
        UIManager.mainCanvas.SetActive(false);
        UIManager.chooseCarCanvas.SetActive(true);
    }

    //ChooseMenuChooseButton
    public void ChooseButton()
    {
        chosenCar = cars[carIndex];
        SaveActualCar.car = chosenCar;
        Debug.Log(SaveActualCar.car.name);
        
        mainCamera.transform.position = camerasPositions[5].position;
        mainCamera.transform.eulerAngles = camerasPositions[5].eulerAngles;
        UIManager.chooseCarCanvas.SetActive(false);
        UIManager.mainCanvas.SetActive(true);
        UIManager.actualCarText.GetComponent<Text>().text = chosenCar.GetComponent<Car>().CarName;
    }

    public void NextCarButton()
    {
        if (carIndex!=4)
            carIndex++;
        else
            carIndex = 0;

        mainCamera.transform.position = camerasPositions[carIndex].position;
        mainCamera.transform.eulerAngles = camerasPositions[carIndex].eulerAngles;
    }

    public void PreviousCarButton()
    {
        if (carIndex != 0)
            carIndex--;
        else
            carIndex = 4;

        mainCamera.transform.position = camerasPositions[carIndex].position;
        mainCamera.transform.eulerAngles = camerasPositions[carIndex].eulerAngles;
    }

    IEnumerator LoadingScreen()
    {
        float totalProgress = 0;
        for (int i = 0; i < scenesToLoad.Count; i++)
        {
            while (!scenesToLoad[i].isDone)
            {
                totalProgress += scenesToLoad[i].progress;
                loadingProgressBar.fillAmount = totalProgress / scenesToLoad.Count;
                yield return null;
            }
        }
    }
}