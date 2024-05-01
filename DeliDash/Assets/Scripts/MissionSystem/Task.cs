using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Task
{
    public string taskName;
    public Transform pickupLocation;
    public Transform deliveryLocation;
    public TaskStatus taskStatus;

    public Task(string name, Transform playerObj, Transform pickup, Transform delivery)
    {
        taskName = name;
        pickupLocation = new GameObject("Pickup").transform;
        pickupLocation.position = pickup.position;
        deliveryLocation = new GameObject("Delivery").transform;
        deliveryLocation.position = delivery.position;
        taskStatus = TaskStatus.Waiting;
    }

    public void UpdateTask(Vector3 playerPosition)
    {
        if (taskStatus == TaskStatus.Waiting)
        {
            CheckPickup(playerPosition);
        }
        else if (taskStatus == TaskStatus.IsPickedUp)
        {
            CheckDelivery(playerPosition);
        }
    }

    private void CheckPickup(Vector3 playerPosition)
    {
        if (Vector3.Distance(playerPosition, pickupLocation.position) < 1.0f)
        {
            taskStatus = TaskStatus.IsPickedUp;
            Debug.Log(taskName + " picked up!");
        }
    }

    private void CheckDelivery(Vector3 playerPosition)
    {
        if (Vector3.Distance(playerPosition, deliveryLocation.position) < 1.0f)
        {
            taskStatus = TaskStatus.Delivered;
            Debug.Log(taskName + " delivered!");
        }
    }
}