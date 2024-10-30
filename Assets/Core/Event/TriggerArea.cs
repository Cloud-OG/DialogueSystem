using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    //事件触发器
    public int id;
    void OnTriggerEnter(Collider other)
    {
        GameEvents.current.DoorwayTriggerEnter(id);
    }
    void OnTriggerExit(Collider other)
    {
        GameEvents.current.DoorwayTriggerExit(id);  
        
    }
}