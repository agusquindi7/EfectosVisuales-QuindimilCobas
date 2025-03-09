using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistWarningState : ScientistBaseState
{
    public override void OnAwake(FSM_Manager sct)
    {
        sct.tmpro.text = "WARNING STATE";
        sct.tmpro.color = Color.red;
        sct.counter = 0;
        sct.fovMesh.SetActive(false);
        if (!sct.hasAlreadySaid2)
        {
            sct.dialogues[1].SetActive(true);
            AudioManager.instance.AlertedScientists(sct.scientistAudios[1], 1f);
            AudioManager.instance.PlayWarningMusic();
            sct.hasAlreadySaid2 = true;
        }

    }

    public override void OnUpdate(FSM_Manager sct)
    {
        if (Vector3.Distance(sct.transform.position, sct.waypoints[2].transform.position) > 0.2f)
        {
            float rotationSpeed = 0.05f;
            Quaternion currentRot = sct.transform.rotation;
            Quaternion targetRot = sct.waypoints[2].transform.rotation;

            sct.transform.rotation = Quaternion.Slerp(currentRot, targetRot, rotationSpeed);

            sct.transform.position += (sct.waypoints[2].transform.position - sct.transform.position).normalized * Time.deltaTime * (sct.speed * 2f);
        }
        else
        {
            Animator anim = sct.button.gameObject.GetComponent<Animator>();
            sct.anim.SetTrigger("isOnButton");
            anim.SetTrigger("isPressed");
            //sct.DefeatPanel();
        }
    }

    public override void OnExit(FSM_Manager sct)
    {

    }
}
