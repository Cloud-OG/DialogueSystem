using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    //单例模式
    public static GameEvents current;
    void Awake()
    {
        current = this;
    }

    //事件行为
    public event Action<int> onDoorwayTriggerEnter;//进门
    public void DoorwayTriggerEnter(int id)
    {
        if (onDoorwayTriggerEnter != null)
        {
            onDoorwayTriggerEnter(id);
        }
    }
    public event Action<int> onDoorwayTriggerExit;//出门
    public void DoorwayTriggerExit(int id)
    {
        if (onDoorwayTriggerExit != null)
        {
            onDoorwayTriggerExit(id);
        }
    }

    
}
