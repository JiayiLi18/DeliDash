using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskUI : MonoBehaviour
{
    public TextMeshProUGUI taskStatusText;

    public void UpdateTaskUI(Task task)
    {
        string taskStatus = "Task Status:\n";
        if (task.taskStatus == TaskStatus.IsPickedUp)
        {
            taskStatus += "Takeaway Picked Up\n";
            if (task.taskStatus == TaskStatus.Delivered)
            {
                taskStatus += "Takeaway Delivered";
            }
            else
            {
                taskStatus += "On the way to Delivery";
            }
        }
        else
        {
            taskStatus += "Takeaway Not Picked Up";
        }
        taskStatusText.text = taskStatus;
    }
}
