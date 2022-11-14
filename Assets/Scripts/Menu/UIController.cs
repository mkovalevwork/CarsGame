using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public UIMap UIMap;

    public void StartButton()
    {
        UIMap.mainCanvas.SetActive(false);
        UIMap.chooseCarCanvas.SetActive(false);
        UIMap.loadingBarCanvas.SetActive(true);
    }

    public void ChooseCarButton()
    {
        UIMap.mainCanvas.SetActive(false);
        UIMap.chooseCarCanvas.SetActive(true);
    }

    public void ChooseButton()
    {
        UIMap.chooseCarCanvas.SetActive(false);
        UIMap.mainCanvas.SetActive(true);
    }

    public Text GetActualCarTextComponent()
    {
        return UIMap.actualCarText.GetComponent<Text>();
    }
}
