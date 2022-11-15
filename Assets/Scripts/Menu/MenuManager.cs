using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _chosenCar;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private UIController _UIController;
    
    public List<GameObject> _cars = new List<GameObject>();
    private int _carIndex = 0;

    public Image loadingProgressBar;
    public List<AsyncOperation> scenesToLoad = new List<AsyncOperation> ();

    public void StartButton()
    {
        
        if (_chosenCar != null)
        {
            DontDestroyOnLoad(_chosenCar);        
            scenesToLoad.Add(SceneManager.LoadSceneAsync(1));
            _UIController.StartButton();
            StartCoroutine("LoadingScreen");           
        }
    }

    //StartManuChoseButton
    public void ChooseCarButton()
    {
        _cameraController.ChangeCamera(_carIndex);
        _UIController.ChooseCarButton();
    }

    //ChooseMenuChooseButton
    public void ChooseButton()
    {
        _chosenCar = _cars[_carIndex];
        SaveActualCar.car = _chosenCar;
;
        _cameraController.ChangeCamera(_cameraController.camerasPositions.Count-1);
        _UIController.ChooseButton();
        _UIController.GetActualCarTextComponent().text = _chosenCar.GetComponent<Car>().CarName;

    }

    public void NextCarButton()
    {
        if (_carIndex != (_cars.Count-1))
            _carIndex++;
        else
            _carIndex = 0;

        _cameraController.ChangeCamera(_carIndex);
    }

    public void PreviousCarButton()
    {
        if (_carIndex != 0)
            _carIndex--;
        else
            _carIndex = (_cars.Count - 1);

        _cameraController.ChangeCamera(_carIndex);
    }

    private IEnumerator LoadingScreen()
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