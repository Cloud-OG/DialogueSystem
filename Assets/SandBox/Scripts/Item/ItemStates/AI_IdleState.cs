using UnityEngine;

public class AI_IdleState : IState
{
    private FSM fsm;            // 有限状态机
    private ItemBlackboard blackboard; // 物品的黑板

    public AI_IdleState(FSM fsm)
    {
        // 初始化状态
        this.fsm = fsm;
        // 将黑板数据转换为 EnemyBlackboard
        this.blackboard = fsm.blackboard as ItemBlackboard;
    }
    
    public void OnEnter()
    {
		    //进入状态执行的操作逻辑
    }

    public void OnExit()
    {
		    //退出状态执行的操作逻辑
    }

    public void OnUpdate()
    {
		//处状态中执行的操作逻辑
        if (Input.GetMouseButtonDown(0))
        {
            this.fsm.SwitchState(StateType.Rotate);
        }
    }
}