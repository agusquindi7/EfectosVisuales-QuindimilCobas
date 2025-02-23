using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIM
{
    private Controls _controls;
    private Movement _movement;
    private Material _aimShadowsMat; //material
    private string _borderFloatRef; //nombre de la referencia

    //private float _raycastDistance;
    //private LayerMask _groundLayer;

    public AIM(Material aimShadowsMat, string borderFloatRef, Movement movement)
    //public AIM (Material aimShadowsMat, string borderFloatRef, float raycastDistance, LayerMask groundLayer)
    {
        _aimShadowsMat = aimShadowsMat;
        _borderFloatRef = borderFloatRef;
        //_raycastDistance = raycastDistance;
        //_groundLayer = groundLayer;
        _movement = movement;
    }

    public void SetControls(Controls controls)
    {
        _controls = controls;
    }
   
    public void UpdateAim() //-1 para "apagarlo", su maximo, 0.2f para "prenderlo"
    {
        //if (Physics.Raycast(_transform.position, Vector3.down, _raycastDistance, _groundLayer) && _velocity.y < 0)        


        //NO SE LE QUITA EL BORDE NO SE PORQUE, AUNQUE SEA TRUE O FALSE SIGUE ESTANDO IGUAL

        //var a = _movement.GetJump();
        //if (_controls.IsAiming() || a == true) //si mantiene el click derecho es true, si esta saltando es true
        //if (!_movement.IsGrounded() && _controls.IsAiming()) //si mantiene el click derecho es true
        if (_controls.IsAiming()) //si mantiene el click derecho es true
        {
            Debug.Log("esta acercando");
            _aimShadowsMat.SetFloat(_borderFloatRef, 0.2f);
        }
        else
        {
            Debug.Log("esta alejando y normal");
            _aimShadowsMat.SetFloat(_borderFloatRef, -1f);
        }
        //Debug.Log(_borderFloatRef);
    }
}
