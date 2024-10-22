using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIM
{
    private Controls _controls;
        
    private Material _aimShadowsMat; //material
    private string _borderFloatRef; //nombre de la referencia

    public AIM (Material aimShadowsMat, string borderFloatRef)
    {
        _aimShadowsMat = aimShadowsMat;
        _borderFloatRef = borderFloatRef;
    }

    public void SetControls(Controls controls)
    {
        _controls = controls;
    }

    public void UpdateAim()
    {    
        //-1 para "apagarlo", su maximo, 0.2f para "prenderlo"
        Debug.Log(_borderFloatRef);
        if (_controls.IsAiming()) //si mantiene el click derecho es true
        {
            Debug.Log("esta entrando");
            _aimShadowsMat.SetFloat(_borderFloatRef, 0.2f);
        }
        else
        {
            Debug.Log("NO esta entrando");
            _aimShadowsMat.SetFloat(_borderFloatRef, -1f);
        }
    }
}
