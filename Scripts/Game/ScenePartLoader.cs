using UnityEngine.SceneManagement;
using UnityEngine;

public enum CheckMethod
{
    Distance,
    Trigger
}

public class ScenePartLoader : MonoBehaviour
{
    public CheckMethod checkMethod;
    public Transform player;
    public float loadRange;

    private bool isLoaded;
    private bool shouldLoad;

    private void Update()
    {
        if (checkMethod == CheckMethod.Distance)
            DistanceCheck();
        else if (checkMethod == CheckMethod.Trigger)
            TriggerCheck();
    }

    void DistanceCheck()
    {
        if (Vector3.Distance(player.position, transform.position) < loadRange)
            LoadScene();
        else
            UnLoadScene();
    }

    void TriggerCheck()
    {
        if (shouldLoad)
            LoadScene();
        else
            UnLoadScene();
    }

    void LoadScene()
    {
        if (!isLoaded)
        {
            SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
            isLoaded = true;
        }
    }

    void UnLoadScene()
    {
        if (isLoaded)
        {
            SceneManager.UnloadSceneAsync(gameObject.name);
            isLoaded = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            shouldLoad = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            shouldLoad = false;
    }
}
