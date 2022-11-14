using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private string _carName;
    [SerializeField] private float _carSpeedForward;
    [SerializeField] private float _carSpeedRotation;

    //public string CarName { get { return _carName; } }  //readonly
    public string CarName { get => _carName; }                   //readonly
    public float CarSpeedForward { get => _carSpeedForward; }    //readonly
    public float CarSpeedRotation { get => _carSpeedRotation; }  //readonly

    public void SuperPower()
    {
        
    }
}