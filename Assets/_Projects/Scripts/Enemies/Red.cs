using UnityEngine.AI;

public class Red : Enemy
{
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
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
            case STATE.IDLE:
                BlockEnemy();
                break;
            case STATE.CHASE:
                MoveToPlayer();
                break;
        }
    }
}
