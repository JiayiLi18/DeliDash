using UnityEngine;
using System;

public class PlayerInteractionController : MonoBehaviour
{
    public event Action OnTrafficViolation;
    private bool hasViolated = false;
    [SerializeField] private GameObject violatingAllert;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TrafficLight"))
        {
            TrafficLightController trafficLight = FindTrafficLightController(other);
            if (trafficLight != null && trafficLight.IsRedLight())
            {
                Debug.Log("Violation: Player ran a red light!");
                HandleTrafficViolation(true);
                OnTrafficViolation?.Invoke();
                hasViolated=true;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
         if (other.CompareTag("TrafficLight"))
        {
            TrafficLightController trafficLight = FindTrafficLightController(other);
            if(trafficLight != null && !trafficLight.IsRedLight()){
                HandleTrafficViolation(false);
                hasViolated=false;
            }
            else if (!hasViolated && trafficLight != null && trafficLight.IsRedLight())
            {
                Debug.Log("Violation: Player ran a red light!");
                HandleTrafficViolation(true);
                OnTrafficViolation?.Invoke();
                hasViolated=true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        HandleTrafficViolation(false);
        hasViolated=false;
    }

    private TrafficLightController FindTrafficLightController(Collider2D collider)
    {
        // Check the parent GameObject first
        TrafficLightController controller = collider.GetComponentInParent<TrafficLightController>();

        // If not found, check higher in the hierarchy
        if (controller == null)
        {
            controller = collider.transform.parent.parent.GetComponent<TrafficLightController>();
        }
        return controller;
    }

    private void HandleTrafficViolation(bool isViolating)
    {
        if (isViolating)
        {
            violatingAllert.SetActive(true);
        }
        else
        {
            violatingAllert.SetActive(false);
        }
    }
}
