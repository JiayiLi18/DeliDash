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

    public List<Task> tasks = new List<Task>();

    void Start()
    {
        UpdateTaskUI();
    }

    void Update()
    {
        foreach (Task task in tasks)
        {
            task.UpdateTask(player.transform.position);
        }
    }

    

    void UpdateTaskUI()
    {
        foreach (Task task in tasks)
        {
            taskUI.UpdateTaskUI(task); 
        }
    }
}