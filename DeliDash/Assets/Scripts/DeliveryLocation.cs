using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryLocation : MonoBehaviour
{
    //private QuestManager questManager;

    void Start()
    {
        //questManager = FindObjectOfType<QuestManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
        /* Check if the player's bag has the right goods to be delivered          
        //You can add additional logic here, like if it's completed on time
        {questManager.CompleteQuest(inTime or not);}
        */
        }
    }
}
