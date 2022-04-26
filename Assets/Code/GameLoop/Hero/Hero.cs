using System;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private HeroData _data;
    [SerializeField] private Turret _turret;

    private void Start()
    {
        StartShooting();
    }

    public void StartShooting()
    {
        _turret.StartTurretShooting(_data.AttackSpeed);
    }
}