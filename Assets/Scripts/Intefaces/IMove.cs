using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove
{
    //A futuro sobre alguna trampa/bala/enemigo que te stunee
    void canMove(bool ismMoving);
}
