using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpSO", menuName = "Scriptable Objects/PowerUpSO")]
public class PowerUpSO : ScriptableObject
{
    [SerializeField] private PowerUpType PowerUpType;
    [SerializeField] private float Balioa;
    [SerializeField] private float Iraupena;


    public PowerUpType GetPowerUpType
    {
        get { return PowerUpType; }
    }

    public float GetBalioa
    {
        get { return Balioa; }
    }


    public float GetIraupena
    {
        get { return Iraupena; }
    }

}


public enum PowerUpType
{
    Speed,
    Torque
}