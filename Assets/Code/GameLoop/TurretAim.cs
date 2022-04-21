using UnityEditor;
using UnityEngine;

public class TurretAim : MonoBehaviour
{
    [SerializeField] [Range(0, 180f)] private float _angle = 45f;
    [SerializeField] private float _maxTurnSpeed = 90f;

    private EnemyDetector _detector;
    private Transform _target;
    private Enemy _currentEnemyTarget;
    private bool isOutOfRange;
    private bool isAimed;
    private bool haveTarget;

    private void Awake()
    {
        _detector = GetComponentInParent<EnemyDetector>();
    }

    private void OnEnable()
    {
        _detector.OnEnemyDetected += OnEnemyDetected;
        _detector.OnEnemyUnobserved += OnEnemyUnobserved;
    }

    private void Update()
    {
        if (!_target)
            return;

        Aim(_target.position);
    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        var range = 20f;
        var dashLineSize = 2f;
        var turret = transform;
        var origin = turret.position;
        var hardpoint = turret.parent;

        if (!hardpoint) return;
        var from = Quaternion.AngleAxis(-_angle, hardpoint.up) * hardpoint.forward;

        Handles.color = new Color(0, 1, 1, .1f);
        Handles.DrawSolidArc(origin, turret.up, from, _angle * 2, range);

        if (!_target) return;

        var projection = Vector3.ProjectOnPlane(_target.position - turret.position, hardpoint.up);

        Handles.color = Color.white;
        Handles.DrawDottedLine(_target.position, turret.position + projection, dashLineSize);

        if (Vector3.Angle(hardpoint.forward, projection) > _angle)
            return;

        Handles.color = Color.red;
        Handles.DrawLine(turret.position, turret.position + projection);

        Handles.color = Color.green;
        Handles.DrawWireArc(origin, turret.up, from, _angle * 2, projection.magnitude);
        Handles.DrawSolidDisc(turret.position + projection, turret.up, .5f);
#endif
    }

    private void OnDisable()
    {
        _detector.OnEnemyDetected -= OnEnemyDetected;
        _detector.OnEnemyUnobserved -= OnEnemyUnobserved;
    }

    private void Aim(Vector3 targetPoint)
    {
        var turret = transform;
        var hardpoint = turret.parent;

        var direction = targetPoint - turret.position;
        direction = Vector3.ProjectOnPlane(direction, hardpoint.up);
        var signedAngle = Vector3.SignedAngle(hardpoint.forward, direction, hardpoint.up);

        isOutOfRange = false;
        if (Mathf.Abs(signedAngle) > _angle)
        {
            isOutOfRange = true;
            direction = hardpoint.rotation * Quaternion.Euler(0, Mathf.Clamp(signedAngle,
                -_angle, _angle), 0) * Vector3.forward;
        }

        var rotation = Quaternion.LookRotation(direction, hardpoint.up);

        isAimed = false;
        if (rotation == transform.rotation && !isOutOfRange)
        {
            isAimed = true;
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation,
            _maxTurnSpeed * Time.deltaTime);
    }

    private void SetTarget(Transform target)
    {
        _target = target;
        haveTarget = true;

        Debug.Log($"Current target - {target.gameObject.name}");
    }

    private void SetEnemyAsTarget(Enemy enemy)
    {
        SetTarget(enemy.transform);
        _currentEnemyTarget = enemy;
    }

    private void SetClosestEnemyAsTarget()
    {
        Enemy newEnemy = _detector.GetClosestEnemy(transform);
        
        if (newEnemy)
            SetEnemyAsTarget(newEnemy);
        else
            Debug.Log("Can not find closest enemy");
    }

    private void ResetTarget()
    {
        if (_target)
        {
            _target = null;
            _currentEnemyTarget = null;
            haveTarget = false;
        }
    }

    private void OnEnemyDetected(Enemy enemy)
    {
        if (!_currentEnemyTarget)
            SetEnemyAsTarget(enemy);
    }

    private void OnEnemyUnobserved(Enemy enemy)
    {
        if (_currentEnemyTarget == enemy)
        {
            ResetTarget();
            SetClosestEnemyAsTarget();
        }
    }
}