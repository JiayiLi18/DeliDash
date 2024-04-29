using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficPoliceController : MonoBehaviour
{
   // The penalty to be applied for traffic light violations
    public int violationPenalty = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Subscribe to the player's OnTrafficViolation event
            collision.GetComponent<PlayerInteractionController>().OnTrafficViolation += HandleTrafficViolation;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Unsubscribe from the player's OnTrafficViolation event
            collision.GetComponent<PlayerInteractionController>().OnTrafficViolation -= HandleTrafficViolation;
        }
    }

    private void HandleTrafficViolation()
    {
        // Apply the penalty
        Debug.Log("Traffic violation detected within police detection area. Penalty applied.");
        PlayerScoreManager.Instance.AddTrafficViolationScore(violationPenalty);
    }
}
