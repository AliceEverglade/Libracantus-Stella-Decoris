using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Ellipse orbitPath;
    [SerializeField] private Vector3 offSet;

    [Range(0f, 1f)]
    [SerializeField] private float orbitProgress = 0f;
    [SerializeField] private float Speed = 0f;
    private float minSpeed = 0.1f;
    private float orbitSpeed => Speed == 0 ? 1f / minSpeed : 1f / Speed;

    [SerializeField] private bool orbitActive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        if(target == null)
        {
            target = GetComponentInChildren<Transform>();
            orbitActive = false;
            return;
        }
        SetTargetPos();
        StartCoroutine(AnimateOrbit());
    }
    
    private void SetTargetPos()
    {
        Vector3 targetPos = orbitPath.Evaluate(orbitProgress) + offSet;
        target.localPosition = targetPos;
    }

    private IEnumerator AnimateOrbit()
    {
        if(Mathf.Abs(Speed) < minSpeed)
        {
            Speed = minSpeed;
        }
        while (orbitActive)
        {
            orbitProgress += Time.deltaTime * orbitSpeed;
            orbitProgress %= 1f;
            SetTargetPos();
            yield return null;
        }
    }
}
