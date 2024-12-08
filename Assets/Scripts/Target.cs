using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public static float targetcount;

    [Header("Y-axis")]
    [SerializeField] private float waveSpeedY = 1;
    [SerializeField] private float waveAmountY = 1;
    [Header("X-axis")]
    [SerializeField] private float waveSpeedX = 1;
    [SerializeField] private float waveAmountX = 1;

    Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        transform.localPosition = startPosition + new Vector3(Mathf.Sin(Time.time * waveSpeedX) * waveAmountX, Mathf.Sin(Time.time * waveSpeedY) * waveAmountY, 0);
    }

    private void Awake()
    {
        targetcount++;
    }
    private void OnDestroy()
    {
        targetcount--;
    }
}
