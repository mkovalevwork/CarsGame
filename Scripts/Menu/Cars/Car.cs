using UnityEngine;

public class Car : MonoBehaviour, IMovable
{
    [SerializeField] protected string carName;
    [SerializeField] protected float carSpeedForward;
    [SerializeField] protected float carSpeedRotation;

    public string CarName { get { return carName; } }  //readonly
    public float CarSpeedForward { get { return carSpeedForward; } }  //readonly
    public float CarSpeedRotation { get { return carSpeedRotation; } }  //readonly

    public void SuperPower()
    {
        
    }
}