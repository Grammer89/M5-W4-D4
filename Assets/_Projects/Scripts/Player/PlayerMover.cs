using UnityEngine;
using UnityEngine.AI;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] PlayerHandlerAnimator _handleAnimator;
    private Camera _cam;
    private Vector3 _hitPoint;
    

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

        _cam = Camera.main;

        _handleAnimator = GetComponent<PlayerHandlerAnimator>();
        _handleAnimator.SetIdle();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DestinationPlayer();
        }
        HandleIdlePlayer();
    }

    public void DestinationPlayer()
    {
        _handleAnimator.SetRun();

        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            _agent.SetDestination(hit.point);
            _hitPoint = hit.point;
        }
    }

    public void HandleIdlePlayer()
    {


        float lenghtBetweenPlayerAndHitPoint = Mathf.Abs(_hitPoint.magnitude - gameObject.transform.position.magnitude);
        if (lenghtBetweenPlayerAndHitPoint <= 0.1f)
        {
            _handleAnimator.SetIdle();
            return;
        }

    }

}
