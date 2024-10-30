using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 状态接口
public interface IState
{
    void OnEnter();   // 进入状态时调用的方法
    void OnExit();    // 退出状态时调用的方法
    void OnUpdate();  // 每帧更新时调用的方法
    // void OnCheck();
    // void OnFixedUpdate();
}

// 共享数据类
[Serializable]
public class Blackboard
{
    // 在此处存储共享数据，或者向外展示的数据，可配置的变量数据
}

// 有限状态机类
public class FSM
{
    public IState curState;                      // 当前状态
    public Dictionary<StateType, IState> states; // 存储<状态类型，状态操作>的字典
    public Blackboard blackboard;                // 共享数据的黑板
    
    public FSM(Blackboard blackboard)
    {
        this.states = new Dictionary<StateType, IState>(); // 初始化状态字典
        this.blackboard = blackboard;                      // 初始化共享数据
    }

    // 添加状态到状态字典
    public void AddState(StateType stateType, IState state)
    {
        if (states.ContainsKey(stateType))
        {
            Debug.Log("[AddState] >>>>>>>>>>> map has contain key:" + stateType);
            return;
        }
        states.Add(stateType, state);
    }
    
    // 切换状态
    public void SwitchState(StateType stateType)
    {
        if (!states.ContainsKey(stateType))
        {
            Debug.Log("[SwitchState] >>>>>>>>>>>> not contain key:" + stateType);
            return;
        }
        if (curState != null)
        {
            curState.OnExit();  // 退出当前状态
        }
        curState = states[stateType]; // 切换到新状态
        curState.OnEnter();            // 进入新状态
    }

    // 更新当前状态
    public void OnUpdate()
    {
        curState.OnUpdate();
    }

    // public void OnFixedUpdate()
    // {
    //     //curState.OnFixedUpdate
    // }

    // public void OnCheck()
    // {
    //     //curState.OnCheck();
    // }
}
