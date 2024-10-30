using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// 物品的AI
[Serializable]
public class ItemBlackboard : Blackboard
{
    public float rotateSpeed = 90f;     // 旋转速度
    public Transform transform; // 物品的 Transform
}