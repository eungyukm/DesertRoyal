using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using UnityEngine;
using UnityEngine.Events;

public class ThinkingPlaceable : Placeable
{
    public States state = States.Dragged;
    public enum States
    {
        // 플레이어가 카드를 끌 때
        Dragged,
        // 플레이어가 맨 처음 떨어 졌을 때
        Idle,
        // 목표를 향해 나아가기
        Seeking,
        // 공격 주기
        Attacking,
        // 정지된 애니메이션, 플레이 필드에서 제거하기 전
        Dead
    }

    public AttackType attackType;
    public enum AttackType
    {
        Melee,
        Ranged,
    }

    public ThinkingPlaceable target;

    public float hitPoints;
    public float attackRange;
    public float lastBlowTime = -1000f;
    public float damage;


    public UnityAction<ThinkingPlaceable> OnDealDamage;

    public virtual void SetTarget(ThinkingPlaceable t)
    {
        target = t;
        t.OnDie += TargetsDead;
    }

    public virtual void StartAttack()
    {
        state = States.Attacking;
    }

    public virtual void DealBlow()
    {
        lastBlowTime = Time.time;
    }

    public virtual void DealDamage()
    {
        if (attackType == AttackType.Melee)
        {
            
        }

        if (OnDealDamage != null)
        {
            OnDealDamage(this);
        }
    }

    public virtual void Seek()
    {
        state = States.Seeking;
    }
    
    

    protected void TargetsDead(Placeable p)
    {
        state = States.Idle;

        target.OnDie -= TargetsDead;
    }

    public bool IsTargetInRnage()
    {
        return (transform.position - target.transform.position).sqrMagnitude <= attackRange * attackRange;
    }

    public float SufferDamage(float amount)
    {
        hitPoints -= amount;
        if (state != States.Dead && hitPoints <= 0f)
        {
            Die();
        }

        return hitPoints;
    }

    public virtual void Stop()
    {
        state = States.Idle;
    }

    protected virtual void Die()
    {
        state = States.Dead;

        if (OnDie != null)
        {
            OnDie(this);
        }
    }
}
