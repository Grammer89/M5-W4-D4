using UnityEngine;
using UnityEngine.AI;

public class Blue : Enemy
{
    [SerializeField] Transform[] _pathEnemy;
    // Start is called before the first frame update

    private int _indexPath = 0;
    private STATE _lasteState;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(_pathEnemy[_indexPath].position);
    }
    void Start()
    {
        StartCoroutine(ChangeOfState());
    }

    // Update is called once per frame
    void Update()
    {

        switch (_state)
        {
            case STATE.PATROL:
                Move();
                break;
            case STATE.IDLE:
                BlockEnemy();
                break;
            case STATE.CHASE:
                MoveToPlayer();
                break;
        }
        _lasteState = _state;
    }

    public override void Move()
    {

        //float lenghtBetweenPlayerAndHitPoint = Mathf.Abs(_pathEnemy[_indexPath].position.magnitude - gameObject.transform.position.magnitude);
        /* if (lenghtBetweenPlayerAndHitPoint <= 0.1f || _lasteState != STATE.PATROL*/

        //{
        if (_indexPath == _pathEnemy.Length - 1)
        {
            _indexPath = 0;
        }
        else
        {
            _indexPath += 1;
        }
        _agent.ResetPath();
        _agent.SetDestination(_pathEnemy[_indexPath].position);
    }
}

