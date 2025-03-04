using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerLife : Entities, IDamageable
{
    [SerializeField] Material damageNerves;
    [SerializeField] float cdNerves;
    [SerializeField] float currentFloat;
    [SerializeField] Animator animator;

    private void Start()
    {
        damageNerves.SetFloat("_BorderStrenght", 0);

        if (animator==null) animator = GetComponent<Animator>();
    }

    private void Update()
    {

        if (currentFloat != 0)
        {
            currentFloat -= Time.deltaTime;
            damageNerves.SetFloat("_BorderStrenght", currentFloat);
        }
        
        currentFloat = Mathf.Clamp(currentFloat, 0, 1.6f);

        if(life <= 0)
        {
            animator.SetTrigger("isDeath");
        }
    }

    //public override bool LifeRemaining()
    //{
    //    if(life <= 0)
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //        return true;
    //    }
    //    return false;
    //}

    public override void TakeDamage (float dmg)
    {
        base.TakeDamage(dmg);
        currentFloat = 1.6f;
        damageNerves.SetFloat("_BorderStrenght", currentFloat);
    }
}
