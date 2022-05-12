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

    public void StartShooting()
    {
        _firearms.StartShooting(_data.AttackSpeed);
    }
}