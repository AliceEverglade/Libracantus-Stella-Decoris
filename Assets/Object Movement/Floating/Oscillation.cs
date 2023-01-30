using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillation : MonoBehaviour
{
    [SerializeField] private Vector3 Origin;
    [SerializeField] private bool IsOscillating;
    [SerializeField] private float Speed;
    [SerializeField] private float Amplitude;
    // Start is called before the first frame update
    void Start()
    {
        Origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOscillating)
        {
            transform.position = new Vector3(0, Mathf.Sin(Time.time * Speed) * Amplitude, 0) + Origin;
        }
    }
}
