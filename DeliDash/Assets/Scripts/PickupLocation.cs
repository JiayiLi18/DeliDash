using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLocation : MonoBehaviour
{
    //private QuestManager questManager;
    void Start()
    {
        //questManager = FindObjectOfType<QuestManager>();
        //questMng contains all the pickupLocations and assign goods randomly to them
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //if has any goods && player press a pickup key
            //give all the goods to player(may have limited bag space)
            //tell QuestMng in this quest the goods has been picked up
        }
    }

    //upon assigned by a quest:
    //GenerateGoods();
    private void GenerateGoods()
    {
        // Generate goods for this pickup location
        // You can customize this based on your game's requirements
    }

}
