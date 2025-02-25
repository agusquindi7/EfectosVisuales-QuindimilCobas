using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Factory2<T> : MonoBehaviour//una clase con generi
{
    public abstract T Create();
}