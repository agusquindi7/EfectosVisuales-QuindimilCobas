using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public abstract class Factory : MonoBehaviour
public abstract class Factory<T> : MonoBehaviour//una clase con generic
{
   //public abstract Bullets Create();
   public abstract T Create();


}