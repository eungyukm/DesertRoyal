using UnityEngine;
using UnityEngine.AI;

// 휴머노이드 또는 걸어다닐 수 있는
public class Unit : ThinkingPlaceable
{
    private float speed;

    private Animator _animator;
    private NavMeshAgent _navMeshAgent;

    public GameObject target;

    public bool hasTarget = false;

    private void Awake()
    {
        pType = Placeable.PlaceableType.Unit;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
        target = GameObject.Find("Target");
        SetTarget(target.GetComponent<ThinkingPlaceable>());
    }

    public void Activate(Faction pFaction)
    {
        faction = pFaction;

        Seek();
        // state = States.Idle;
    }

    public override void SetTarget(ThinkingPlaceable t)
    {
        base.SetTarget(t);
        
        Debug.Log("하위 메서드!!");
        hasTarget = true;
    }

    public override void Seek()
    {
        if (target == null)
        {
            return;
        }
        
        base.Seek();
        
        _navMeshAgent.SetDestination(target.transform.position);
    }
    
    // 유닛이 목표에 도달했습니다.
    public override void StartAttack()
    {
        base.StartAttack();
        
        
    }

    private void Update()
    {
        if (!hasTarget)
        {
            return;
        }
        _navMeshAgent.SetDestination(target.transform.position);
    }

    public override void DealBlow()
    {
        base.DealBlow();
    }

    public override void Stop()
    {
        base.Stop();
    }

    protected override void Die()
    {
        base.Die();
    }
}
