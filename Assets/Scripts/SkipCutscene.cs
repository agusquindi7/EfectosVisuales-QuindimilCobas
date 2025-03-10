using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Playables;

public class SkipCutscene : MonoBehaviour
{
    public PlayableDirector director;

    private void Update()
    {
        if(Input.anyKeyDown && director.isActiveAndEnabled)
        {
            double durationCutscene = director.duration;

            director.time = durationCutscene - 1f;
        }
    }
}
