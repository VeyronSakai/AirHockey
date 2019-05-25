using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFromSmartphone : MonoBehaviour, IInput
{
    //しきい値を設定
    private float threshold = 0.1f;

    public Vector3 MoveVector
    {
        get
        {
            if (Input.acceleration.x > this.threshold)
            {
                return new Vector3(1, 0, 0);
            }
            else if (Input.acceleration.x < -this.threshold)
            {
                return new Vector3(-1, 0, 0);
            }
            else
            {
                return new Vector3(0, 0, 0);
            }
        }
    }
}
