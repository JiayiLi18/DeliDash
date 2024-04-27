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
        if (task.isPickedUp)
        {
            taskStatus += "Takeaway Picked Up\n";
            if (task.isDelivered)
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
