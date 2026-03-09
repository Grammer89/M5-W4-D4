using System.Collections;
using UnityEngine;


public class LineOfSight : MonoBehaviour
{
    [SerializeField] LineRenderer _lineRenderer;
    [SerializeField] private int _sides = 20;
    [SerializeField] private float _viewAngle = 30f;
    [SerializeField] private float _sightDistance = 10f;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _transform;

    // Start is called before the first frame update
    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(ConeOfView());

    }

    IEnumerator ConeOfView()
    {
        WaitForSeconds wFS = new (0.1f);
        while (true)
        {
            yield return wFS;
            EvaluateConeOfView(_sides);
        }
    }

    public float GetViewAnlge()
    { return _viewAngle; }
    public void EvaluateConeOfView(int subdivision)
    {
        float startAngle = -_viewAngle;

        int points = subdivision + 1;

        _lineRenderer.positionCount = points;

        Vector3 forward = _transform.forward;
        Vector3 lineOrigin = _transform.position;
        Vector3 raycastOrigin = _transform.position + new Vector3(0f, 0.05f, 0f);
        _lineRenderer.SetPosition(0, lineOrigin);

        float deltaAngle = (2 * _viewAngle / subdivision);

        for (int i = 0; i < subdivision; i++)
        {
            float currentAngle = startAngle + deltaAngle * i;
            Vector3 direction = Quaternion.Euler(0, currentAngle, 0) * forward;
            Vector3 point = _transform.position + direction * _sightDistance;
            if (Physics.Raycast(raycastOrigin, direction, out RaycastHit hit, _sightDistance, _layerMask))
            {
                point = hit.point - (raycastOrigin - lineOrigin);
            }
            _lineRenderer.SetPosition(i + 1, point);
        }

    }
}
