using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRespawn : MonoBehaviour
{
    Vector3 respawnPoint;
    string respawnSceneName;
    CharacterDefeatHandler characterDefeat;
    [SerializeField] Animator animator;

    private void Awake()
    {
        characterDefeat = GetComponent<CharacterDefeatHandler>();
    }

    private void Start()
    {
        respawnPoint = transform.position;
    }


    public void Respawn()
    {
        gameObject.transform.position = respawnPoint;
        characterDefeat.Respawn();
        animator.Play("Idle");
        animator.SetBool("defeated", false);
    }
}
