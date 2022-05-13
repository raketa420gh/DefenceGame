using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private TurretData _data;
    [SerializeField] private Firearms firearms;

    public void StartShooting()
    {
        firearms.StartShooting(_data.AttackSpeed);
    }
}