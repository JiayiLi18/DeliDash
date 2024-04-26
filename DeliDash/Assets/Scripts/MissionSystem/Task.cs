using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task 
{
    public Transform pickupLocation;
    public Transform deliveryLocation;
    public bool isPickedUp;
    public bool isDelivered;

    public Task(Transform pickup, Transform delivery)
    {
        pickupLocation = pickup;
        deliveryLocation = delivery;
        isPickedUp = false;
        isDelivered = false;
    }
}
