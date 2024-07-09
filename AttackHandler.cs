using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    Character character;
    [SerializeField] float attackRange = 1f;
    [SerializeField] float defaultTimeToAttack = 2f;
    float attackTimer;  //Time between attacks
    Animator animator;
    CharacterMovement characterMovement;
    Character target;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
        character = GetComponent<Character>();
    }

    internal void Attack(Character target)
    {
        this.target = target;
        ProcessAttack();
    }

    private void Update()
    {
        AttackTimerTick();
        if (target != null)
        {
            ProcessAttack();
        }
    }

    private void AttackTimerTick()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
    }

    private void ProcessAttack()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);


        if (distance < attackRange)
        {
            if (attackTimer > 0) {return;}

            attackTimer = GetAttackTime();
            characterMovement.Stop();
            animator.SetTrigger("Attack");
            

            target.TakeDamage(character.TakeStats(Statistic.Damage).integer_value);
            target = null;


        }
        else
        {
            characterMovement.SetDestination(target.transform.position);

        }
    }

    float GetAttackTime()
    {
        float attackTime = defaultTimeToAttack;
        attackTime /= character.TakeStats(Statistic.AttackSpeed).float_value;

        return attackTime;
    }
}
