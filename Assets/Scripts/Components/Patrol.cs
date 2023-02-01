using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using CustomLibrary;

[RequireComponent(typeof(NavMeshAgent))]
public class Patrol : MonoBehaviour
{
    public bool IsPatroling
    {
        get { return _isPatroling; }
    }

    [SerializeField] NavMeshAgent _navMeshAgent = null;
    [Min(0f)][SerializeField] float _patrolDistance = 20f;

    bool _isPatroling = false;

    void OnEnable()
    {
        StartPatrol();
    }
    void OnDisable()
    {
        StopPatrol();
    }

    public void StartPatrol()
    {
        if (_isPatroling) return;

        StartCoroutine(_PatrolRoutine());
    }
    public void StopPatrol()
    {
        _isPatroling = false;
    }

    IEnumerator _PatrolRoutine()
    {
        _isPatroling = true;
        _navMeshAgent.destination = transform.position;
        _navMeshAgent.stoppingDistance = 0f;

        while (_isPatroling)
        {
            // µµÂøÇßÀ» ¶§
            if (_navMeshAgent.remainingDistance < 0.05f)
            {
                yield return new WaitForSeconds(Random.Range(0f, 7f));
                _navMeshAgent.destination = Utility.GetRandomPointOnNavMesh(transform.position, Random.Range(0f, _patrolDistance));
            }
            else yield return null;
        }
    }
}
