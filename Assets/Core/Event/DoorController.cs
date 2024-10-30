using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;
    //只允许方法订阅和删除事件
    private void Start()
    {
        //游戏开始时订阅事件
        GameEvents.current.onDoorwayTriggerEnter += OnDoorwayOpen;
        GameEvents.current.onDoorwayTriggerExit += OnDoorwayExit;
    }
    private void OnDoorwayOpen(int id)
    {
        //游戏逻辑
        if (id == this.id)
        {
            
        }

    }
    private void OnDoorwayExit(int id)
    {
        //游戏逻辑
        //游戏逻辑
        if (id == this.id)
        {
            
        }
    }

    
    public void OnDestroy()
    {
        //对象销毁时删除事件
        GameEvents.current.onDoorwayTriggerEnter -= OnDoorwayOpen;
        GameEvents.current.onDoorwayTriggerExit -= OnDoorwayExit;
    }
}