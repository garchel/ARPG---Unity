using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementInput : MonoBehaviour // Faz a comunicação entre o Input e o Movimento do personagem
{

    [SerializeField] MouseInput mouseInput;
    CharacterMovement characterMovement;

    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
    }

    public void MoveInput()
    {
        if (mouseInput != null && characterMovement != null)
        {
            characterMovement.SetDestination(mouseInput.mouseInputPosition);
        }
        else
        {
            if (mouseInput == null)
            {
                Debug.LogError("MouseInput is not assigned.");
            }
            if (characterMovement == null)
            {
                Debug.LogError("CharacterMovement component not found.");
            }
        }
    }

}
