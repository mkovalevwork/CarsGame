using UnityEngine;

public enum CheckMethod
{
    Distance,
    Trigger
}

public class MeshPartActivator : MonoBehaviour
{
    public CheckMethod checkMethod;
    public Transform player;
    public float loadRange;

    private bool _isEnable;
    private bool _isDisable;

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
        if (_isDisable)
            LoadScene();
        else
            UnLoadScene();
    }

    private void LoadScene()
    {
        if (!_isEnable)
            ActivateRenderer();
    }

    private void UnLoadScene()
    {
        if (_isEnable) 
            DeactivateRenderer();
    }

    private void ActivateRenderer()
    {
        GetComponent<MeshRenderer>().enabled = true;
        _isEnable = true;
    }

    private void DeactivateRenderer()
    {
        GetComponent<MeshRenderer>().enabled = false;
        _isEnable = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController playerController))
            _isDisable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController playerController))
            _isDisable = false;
    }
}
