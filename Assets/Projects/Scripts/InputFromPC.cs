using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFromPC : MonoBehaviour, IInput
{
    public Vector3 MoveVector {    

        get{

            return new Vector3(Input.GetAxisRaw("Horizontal"),0,0);

        }

    }
}
