using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    private static TaskManager instance;
    public static TaskManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TaskManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("TaskManager");
                    instance = obj.AddComponent<TaskManager>();
                }
            }

            return instance;
        }
    }
    
    public GameObject player;
    public TaskUI taskUI;

    public List<Task> taskList = new List<Task>();
    private int currentTaskIndex = 0;
    private bool isTaskCompleted = false;

    void Start()
    {
        AcceptTask();
        UpdateTaskUI();
    }

    void Update()
    {
        if (!isTaskCompleted)
        {
            CheckPickup();
        }
        else
        {
            Task currentTask = taskList[currentTaskIndex];
            // Check if the player reaches the delivery location
            if (Vector3.Distance(player.transform.position, currentTask.deliveryLocation.transform.position) < 1.0f)
            {
                CompleteTask();
            }
        }
    }

    void AcceptTask()
    {
        Task currentTask = taskList[currentTaskIndex];
        player.transform.position = currentTask.pickupLocation.transform.position;
    }

    void CheckPickup()
    {
        Task currentTask = taskList[currentTaskIndex];
        if (Vector3.Distance(player.transform.position, currentTask.pickupLocation.transform.position) < 1.0f)
        {
            currentTask.isPickedUp = true;
            UpdateTaskUI();
        }
    }

    void CompleteTask()
    {
        Debug.Log("Task completed!");
        Task currentTask = taskList[currentTaskIndex];
        currentTask.isDelivered = true;
        isTaskCompleted = true;

        currentTaskIndex++;
        if (currentTaskIndex < taskList.Count)
        {
            AcceptTask();
        }
        else
        {
            Debug.Log("All tasks completed!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && !isTaskCompleted)
        {
            isTaskCompleted = true;
        }
    }

    void UpdateTaskUI()
    {
        Task currentTask = taskList[currentTaskIndex];
        taskUI.UpdateTaskUI(currentTask);
    }
}
