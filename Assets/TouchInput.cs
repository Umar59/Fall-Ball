using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public Vector2 StartPos { get; set; }
    public float Direction { get; set; }

    public static event Action<float> OnMove;

    void Update()
    {
        GetInputTouch();
    }


    private void GetInputTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {        
                case TouchPhase.Moved:

                    OnMove?.Invoke(-touch.deltaPosition.x);
                    break;

                default:

                    OnMove?.Invoke(0f);
                    break;
            }
        }


    }
}
