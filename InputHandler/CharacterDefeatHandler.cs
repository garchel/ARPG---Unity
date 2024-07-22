using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterDefeatHandler : MonoBehaviour
{
    NavMeshAgent agent;
    AIEnemy aiEnemy;
    Collider objectCollider;

    AttackInput attackInput;
    InteractInput interactInput;
    PlayerCharacterInput playerCharacterInput;
    CharacterMovementInput movementInput;
    Character character;

    [SerializeField] bool player = false;
    [SerializeField] GameObject defeatedPanel;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        aiEnemy = GetComponent<AIEnemy>();
        objectCollider = GetComponent<Collider>();

        attackInput = GetComponent<AttackInput>();
        interactInput = GetComponent<InteractInput>();
        playerCharacterInput = GetComponent<PlayerCharacterInput>();
        movementInput = GetComponent<CharacterMovementInput>();
        character = GetComponent<Character>();
    }


    public void Defeated()
    {
        SetState(false);
    }

    internal void Respawn()
    {
        SetState(true);
    }

    void SetState(bool state)
    {
        agent.isStopped = !state;
        agent.enabled = state;
        objectCollider.enabled = state;

        // Enemy Components
        if(aiEnemy != null)
        {
            aiEnemy.enabled = state;
        }

        // Player Components
        if (attackInput != null)
        {
            attackInput.enabled = state;
        }

        if (interactInput != null)
        {
            interactInput.enabled = state;
        }

        if (playerCharacterInput != null)
        {
            playerCharacterInput.enabled = state;
        }

        if (movementInput != null)
        {
            movementInput.enabled = state;
        }

        if (defeatedPanel != null)
        {
            defeatedPanel.SetActive(!state);
        }

        if (state == true)
        {
            if (character != null)
            {
                character.Restore();
            }
        }
        
    }
}
