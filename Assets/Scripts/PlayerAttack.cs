using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackArea;

    private bool attacking = false;

    private float timeToAttack = 0.5f;
    private float timer = 0f;
    Animator animator;

    [SerializeField] private AudioSource spellSoundEffect;

    //public GameManager gameManager;
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (attacking)
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
                animator.SetBool("PlyerAttack", false);
            }
        }
    }

    public void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);

        animator.SetBool("PlyerAttack", true);
        spellSoundEffect.Play();
    }

}
