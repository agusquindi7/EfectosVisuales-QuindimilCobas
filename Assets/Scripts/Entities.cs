using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entities : MonoBehaviour
{
    public float life;
    public float maxLife;

    private void Awake()
    {
        life = maxLife;
    }

    public virtual void TakeDamage(float damage)
    {
        if (life > maxLife) life = maxLife;

        life = Mathf.Clamp(life - damage, 0, maxLife);

        LifeRemainingPJ();

    }

    public virtual bool LifeRemainingPJ()
    {
        if (life <= 0) 
        { 
            return true;
            //Destroy(gameObject);
        }
        return false;
    }
}
