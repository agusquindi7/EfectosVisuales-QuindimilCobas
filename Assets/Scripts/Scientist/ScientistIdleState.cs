using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistIdleState : ScientistBaseState
{
    public override void OnAwake(FSM_Manager sct)
    {
        //Inicio animacion de rotacion para empezar a caminar
        sct.tmpro.text = "IDLE STATE";
        sct.tmpro.color = Color.green;
        sct.counter = 0;
        sct.fovMesh.SetActive(false);

        sct.anim.SetBool("isAlerted", false);

        sct.dialogues[0].SetActive(false);
    }

    public override void OnUpdate(FSM_Manager sct)
    {
        if(sct.counter != sct.timeIdle && sct.isOnPlate)
        {   //Si el tiempo es distinto y babitas paso al salon principal empieza el contador de Alerted
            if (!sct.hasAlreadySaid1)
            {
                sct.hasAlreadySaid1 = true;

                AudioManager.instance.AlertedScientists(sct.scientistAudios[0], .5f);
                sct.dialogues[0].SetActive(true);
            }
            sct.counter += Time.deltaTime;
            sct.counter = Mathf.Clamp(sct.counter, 0, sct.timeIdle);
        }
        if (sct.counter == sct.timeIdle) //Si se cumple el tiempo primero roto, y si estoy mirando para hacia donde tengo que ir cambio de estado
        {
            
            float rotationSpeed = 0.015f;
            Quaternion currentRot = sct.transform.rotation;
            Quaternion targetRot = sct.waypoints[1].transform.rotation;

            sct.transform.rotation = Quaternion.Slerp(currentRot, targetRot, rotationSpeed);

            if (sct.transform.rotation == sct.waypoints[1].transform.rotation)
            {
                sct.SwitchState(sct.alertedState);
            }
        }
    }

    public override void OnExit(FSM_Manager sct)
    {
        sct.anim.SetBool("isAlerted", true);
        sct.dialogues[0].SetActive(false);
    }
}
