using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
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
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        HandleTrafficViolation(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Debug.Log("Accident: Player collided with another car!");
            HandleTrafficAccident("car");
        }
        else if (collision.gameObject.CompareTag("Pedestrian"))
        {
            Debug.Log("Accident: Player collided with a pedestrian!");
            HandleTrafficAccident("pedestrian");
        }
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
        // Implement what happens on a traffic rule violation
        Debug.Log("Handle traffic violation logic here. Maybe reduce points or notify the player.");
        if (isViolating)
        {
            violatingAllert.SetActive(true);
        }
        else
        {
            violatingAllert.SetActive(false);
        }
    }

    private void HandleTrafficAccident(string objectType)
    {
        // Implement what happens on a traffic accident
        Debug.Log($"Handle traffic accident logic here. Involved object type: {objectType}.");
        // Possible actions: deduct points, end game, decrease health, etc.
    }
}
