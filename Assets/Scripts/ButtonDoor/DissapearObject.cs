using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearObject : MonoBehaviour, IDissapear
{
    public void Dissapear()
    {
        gameObject.SetActive(false);
    }
}
