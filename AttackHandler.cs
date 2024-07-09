using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    Character character;
    [SerializeField] float attackRange = 1f;
    Animator animator;
    CharacterMovement characterMovement;
    InteractableObject target;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
        character = GetComponent<Character>();
    }

    internal void Attack(InteractableObject target)
    {
        this.target = target;
        ProcessAttack();
    }

    private void Update()
    {
        if (target != null)
        {
            ProcessAttack();
        }
    }

    private void ProcessAttack()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);


        if (distance < attackRange)
        {
            characterMovement.Stop();
            animator.SetTrigger("Attack");
            
            Character targetCharacterToAttack = target.GetComponent<Character>();
            targetCharacterToAttack.TakeDamage(character.TakeStats(Statistic.Damage).value);
            target = null;


        }
        else
        {
            characterMovement.SetDestination(target.transform.position);

        }
    }
}
