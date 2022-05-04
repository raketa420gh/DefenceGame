using UnityEngine;

public class SquadTurretSlot : MonoBehaviour
{
    private Turret _currentTurret;
    private bool isEmpty = true;

    public void SetTurret(Turret turret)
    {
        _currentTurret = turret;
        isEmpty = false;

        turret.transform.position = transform.position;
        turret.transform.parent = transform;
    }
}