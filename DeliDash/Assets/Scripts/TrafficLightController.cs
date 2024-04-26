using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    [SerializeField] private GameObject redLight;
    [SerializeField] private GameObject yellowLight;
    [SerializeField] private GameObject greenLight;
    public int startState;
    public float greenDuration = 5f;
    public float yellowDuration = 1f;
    public float redDuration = 5f;

    private float timer;
    private int currentLight; // 0 = Green, 1 = Yellow, 2 = Red

    void Start()
    {
        currentLight=startState;
        ChangeLight();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ChangeLight();
        }
    }

    void ChangeLight()
    {
        currentLight = (currentLight + 1) % 3;
        switch (currentLight)
        {
            case 0: // Green light
                SetLights(0);
                timer = greenDuration;
                break;
            case 1: // Yellow light
                SetLights(1);
                timer = yellowDuration;
                break;
            case 2: // Red light
                SetLights(2);
                timer = redDuration;
                break;
        }
    }

    void SetLights(int lightIndex)
    {
        greenLight.SetActive(lightIndex == 0);
        yellowLight.SetActive(lightIndex == 1);
        redLight.SetActive(lightIndex == 2);
    }

    public bool IsRedLight()
    {
        return currentLight == 2;
    }
}
