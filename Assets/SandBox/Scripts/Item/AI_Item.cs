using UnityEngine;

public class AI_Item : MonoBehaviour
{
    private FSM fsm;                 // 有限状态机
    public ItemBlackboard blackboard; // 敌人的黑板
    void Start()
    {
        fsm = new FSM(blackboard); // 创建有限状态机并传入黑板数据
        // 添加 IdleState 和 MoveState 到状态机中
        fsm.AddState(StateType.Idle, new AI_IdleState(fsm));
        fsm.AddState(StateType.Move, new AI_MoveState(fsm));
        fsm.AddState(StateType.Rotate, new AI_RotateState(fsm));
        // 初始状态为 Idle
        fsm.SwitchState(StateType.Idle);
    }

    void Update()
    {
        fsm.OnUpdate();
    }

}