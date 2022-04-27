using UnityEngine;

[RequireComponent(typeof(Firearms))]
public class Hero : MonoBehaviour
{
    [SerializeField] private HeroData _data;
    private Firearms _firearms;

    private void Awake()
    {
        _firearms = GetComponent<Firearms>();
    }

    private void Start()
    {
        StartShooting();
    }

    private void StartShooting()
    {
        _firearms.StartTurretShooting(_data.AttackSpeed);
    }
}