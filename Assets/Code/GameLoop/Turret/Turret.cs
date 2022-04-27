using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private TurretData _data;
    [SerializeField] private Firearms firearms;

    private void Start()
    {
        StartShooting();
    }

    public void StartShooting()
    {
        firearms.StartTurretShooting(_data.AttackSpeed);
    }
}