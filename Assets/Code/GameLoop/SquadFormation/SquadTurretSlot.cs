using UnityEngine;

public class SquadTurretSlot : MonoBehaviour
{
    private Turret _currentTurret;
    private bool isEmpty = true;

    public void SetTurret(Turret turret, float yOffset)
    {
        _currentTurret = turret;
        isEmpty = false;

        turret.transform.position = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
        turret.transform.parent = transform;
    }
}