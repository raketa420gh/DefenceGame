using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private HeroData _data;
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