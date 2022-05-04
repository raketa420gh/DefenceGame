using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class FinishArea : MonoBehaviour
{
    public event Action OnEntered;
    private Collider _collider => GetComponent<BoxCollider>();

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<Enemy>();
        
        if (enemy)
            Destroy(enemy.gameObject);

        OnEntered?.Invoke();
    }

    private void OnDrawGizmos()
    {
        Color color = Color.red;
        color.a = 0.5f;
        
        Gizmos.color = color;
        Gizmos.DrawCube(transform.position, _collider.bounds.size);
    }
}