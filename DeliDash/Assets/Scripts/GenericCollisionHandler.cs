using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericCollisionHandler : MonoBehaviour
{
    public enum ObjectType
    {
        Car,
        Pedestrian,
        Police
    }

    public ObjectType objectType;

     private static Dictionary<ObjectType, int> collisionPenalties = new Dictionary<ObjectType, int>()
    {
        { ObjectType.Car, 4 },
        { ObjectType.Pedestrian, 1 },
        { ObjectType.Police, 1 }
        // Define other penalties here
    };

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HandleCollisionWithPlayer();
        }
    }

    void HandleCollisionWithPlayer()
    {
        Debug.Log($"{objectType} has collided with the player!");
        if (collisionPenalties.TryGetValue(objectType, out int penalty))
        {
            PlayerScoreManager.Instance.DeductHP(penalty);
        }
    }
}
