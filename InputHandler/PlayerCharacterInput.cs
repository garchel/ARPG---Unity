using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterInput : MonoBehaviour
{
    [SerializeField] MouseInput mouseInput;

    CharacterMovementInput characterMovementInput;
    AttackInput attackInput;
    InteractInput interactInput;


    private void Awake()
    {
        characterMovementInput = GetComponent<CharacterMovementInput>();
        attackInput = GetComponent<AttackInput>();
        interactInput = GetComponent<InteractInput>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (attackInput.AttackCheck())
            {
                Debug.Log("Attack");
                attackInput.Attack();
                return;
            }

            if (interactInput.InteractCheck())
            {
                Debug.Log("Interact");
                interactInput.Interact();
                return;
            }
            
            Debug.Log("Move");
            interactInput.ResetState();
            characterMovementInput.MoveInput();
        }
    }
}
