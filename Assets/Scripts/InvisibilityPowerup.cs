using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibilityPowerup : MonoBehaviour
{
    private bool hasInvisibility = false;
    [SerializeField] int powerupTime;
    [SerializeField] Material materialBabitas;
    [SerializeField] Material materialInvisibility;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<OnTriggerDestroy>())
        {
            StartCoroutine(InvisibilityPower());
        }
    }

    IEnumerator InvisibilityPower()
    {
        MeshRenderer babitasMesh = GetComponent<MeshRenderer>();
        babitasMesh.material = materialInvisibility;
        gameObject.layer = 10;
        yield return new WaitForSeconds(powerupTime);
        babitasMesh.material = materialBabitas;
        gameObject.layer = 6;
    }
}
