using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInput : MonoBehaviour // Faz a comunicação entre um Input do Player e o AttackHandler
{
    InteractInput interactInput;
    AttackHandler attackHandler;

    private void Awake()
    {
        interactInput = GetComponent<InteractInput>();
        attackHandler = GetComponent<AttackHandler>();
    }

    public void Attack()
    {
        if (interactInput.hoveringOverCharacter != null)
        {
            attackHandler.Attack(interactInput.hoveringOverCharacter);
        }
    }

    public bool AttackCheck()
    {
        return interactInput.hoveringOverCharacter != null;
    }

















}
