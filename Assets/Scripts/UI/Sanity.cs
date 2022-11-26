using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sanity : MonoBehaviour
{
    public Image sanityBar;
    float sanity, maxSanity = 100;

    private void Start()
    {
        sanity = maxSanity;
    }

    private void Update() 
    {
        if (sanity > maxSanity) sanity = maxSanity;
        SanityBarFiller();    
    }

    void SanityBarFiller() 
    {
        sanityBar.fillAmount = sanity / maxSanity;
    }


    //¨ü¶Ë¦^´_
    public void Damage(float damagePoints) 
    {
        if (sanity > 0) sanity -= damagePoints;
    }

    public void Heal(float healingPoints)
    {
        if (sanity < maxSanity) sanity += healingPoints;
    }
}
