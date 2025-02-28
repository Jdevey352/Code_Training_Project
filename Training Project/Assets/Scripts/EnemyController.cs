using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float patrolDelay = 1.5f;
    [SerializeField] private float patrolSpeed = 3;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction = Vector2.right;
    private Vector2 _patrolTargetPosition;
    private WaypointPath _waypointPath;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _waypointPath = GetComponentInChildren<WaypointPath>();
    }

    void Start()
    {
        StartCoroutine(PatrolCoroutine());
    }

    private void FixedUpdate()
    {
        Vector2 dir = _patrolTargetPosition - (Vector2)transform.position;

        if (dir.magnitude < 0.1)
        {
            _patrolTargetPosition = _waypointPath.GetNextWaypointPosition();
            dir = _patrolTargetPosition - (Vector2)transform.position;
        }

        _rigidbody.velocity = dir.normalized * patrolSpeed;

     

        //keep resetting the velocity to the
        //direction * speed even if nudged
        //if (GameManager.Instance.State == GameState.Playing)
        //{
        //    _rigidbody.velocity = _direction * 2;
        //}
        //else
        //{
        //    _rigidbody.velocity = Vector2.zero;
        //}
    }
    public void AcceptDefeat()
    {
        Destroy(gameObject);
    }
    //IEnumerator return type for coroutine
    //that can yield for time and come back
    IEnumerator PatrolCoroutine()
    {
        _patrolTargetPosition = _waypointPath.GetNextWaypointPosition();

        ////change the direction every second
        while (true)
        {
            _direction = new Vector2(1, -1);
            yield return new WaitForSeconds(1);
            _direction = new Vector2(-1, 1);
            yield return new WaitForSeconds(1);
        }
        yield break;
    }
    private void OnEnable()
    {
        GameManager.OnAfterStateChanged += HandleGameStateChange;
    }
    private void OnDisable()
    {
        GameManager.OnAfterStateChanged -= HandleGameStateChange;
    }
    private void HandleGameStateChange(GameState state)
    {
        if (state == GameState.Starting)
        {
            GetComponent<SpriteRenderer>().color = Color.grey;
        }
        if(state == GameState.Playing)
        {
            GetComponent<SpriteRenderer>().color = Color.magenta;
        }
    }
}
