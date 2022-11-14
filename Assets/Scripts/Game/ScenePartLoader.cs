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

    private bool _isLoaded;
    private bool _shouldLoad;

    private void Update()
    {
        if (checkMethod == CheckMethod.Distance)
            DistanceCheck();
        else if (checkMethod == CheckMethod.Trigger)
            TriggerCheck();
    }

    private void DistanceCheck()
    {
        if (Vector3.Distance(player.position, transform.position) < loadRange)
            LoadScene();
        else
            UnLoadScene();
    }

    private void TriggerCheck()
    {
        if (_shouldLoad)
            LoadScene();
        else
            UnLoadScene();
    }

    private void LoadScene()
    {
        if (!_isLoaded)
        {
            SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
            _isLoaded = true;
        }
    }

    private void UnLoadScene()
    {
        if (_isLoaded)
        {
            SceneManager.UnloadSceneAsync(gameObject.name);
            _isLoaded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController playerController))
            _shouldLoad = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController playerController))
            _shouldLoad = false;
    }
}
