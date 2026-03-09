using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public abstract class Enemy : MonoBehaviour
{
    public Transform _transformPlayer;
    public NavMeshAgent _agent;

    public float _distMin = 10f;
    public LayerMask _layerMask;

    private LineOfSight _lineOfSight;


    public STATE _state;

    public enum STATE
    {
        IDLE,
        PATROL,
        CHASE,
        CAPTURE
    }

     public IEnumerator ChangeOfState()
    {
        _lineOfSight = GetComponentInChildren<LineOfSight>();
        while (true)
        {

            yield return null;

            if (!CanSeePlayer())
            {
                _state = STATE.PATROL;
            }

            else

            {
                Vector3 _distance = _transformPlayer.position - transform.position;
                float lenghtBetweenPlayerAndEnemy = _distance.magnitude;
                if (lenghtBetweenPlayerAndEnemy < _distMin && lenghtBetweenPlayerAndEnemy > _distMin - 3)
                {
                    _state = STATE.IDLE;
                }
                else if (lenghtBetweenPlayerAndEnemy < 6f && lenghtBetweenPlayerAndEnemy >= 2f)
                {
                    _state = STATE.CHASE;
                }
                else if (lenghtBetweenPlayerAndEnemy < 2f)
                {
                    _state = STATE.CAPTURE;
                    PlayerManager.Instance.RespawnPlayaer();
                }
            }

            Debug.Log("Stato Enemy : " + _state);
        }
    }

    public virtual void Move()
    {

    }

    public void MoveToPlayer()
    {
        _agent.ResetPath();
        _agent.SetDestination(_transformPlayer.position);
    }

    public void BlockEnemy()
    {
        _agent.ResetPath();
    }
    public bool CanSeePlayer()
    {
        
        Vector3 toTarget = _transformPlayer.position - gameObject.transform.position;
        float sqrDistance = toTarget.magnitude;

        if (sqrDistance > _distMin)
        {
            Debug.Log("Distanza troppo esagerata");
            return false;
        }

        float distance = Mathf.Sqrt(sqrDistance);
        toTarget /= distance;

        if (Vector3.Dot(transform.forward, toTarget) < Mathf.Cos(_lineOfSight.GetViewAnlge() * Mathf.Deg2Rad))
        {
            Debug.Log("Non lo vedo");
            return false;
        }

        if (Physics.Linecast(transform.position, _transformPlayer.position + Vector3.up * 0.01f, _layerMask))
        {
            Debug.Log("Non lo acchiappo");
            return false;
        }

        Debug.Log("Lo vedo");
        return true;
    }
}
