using System;
using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    public float scale = -0.25f;
    public float time = 2f;
    private Vector3 inital;

    private void Start()
    {
        inital = transform.localScale;
    }

    public void MakeSmall()
    {
        transform.localScale = inital * scale;
    }

    public void ResetSize()
    {
        transform.localScale = inital;
    }

    public void MakeSmallWithReset()
    {
        transform.localScale = inital * scale;
        Invoke("ResetSize", time);
    }
}