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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            characterMovement.SetDestination(mouseInput.mouseInputPosition);
        }
    }

}
