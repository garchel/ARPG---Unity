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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (interactInput.hoveringOverObject != null)
            {
                attackHandler.Attack(interactInput.hoveringOverObject);
            }
        }
    }

















}
