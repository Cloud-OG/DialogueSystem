using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour
{
    //BasePanel 是所有界面的父类，他需要继承MonoBehaviour以便挂接在物体身上。
    protected bool isRemove = false;    // 是否移除
    protected new string name;        // 界面名字

    

    /// <summary>
    /// 激活或关闭界面
    /// </summary>
    /// <param name="active"></param> <summary>
    public virtual void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    // 打开界面
    public virtual void OpenPanel(string name)
    {
        this.name = name;
        SetActive(true);
    }

    // 关闭界面
    public virtual void ClosePanel()
    {   
        isRemove = true;
        SetActive(false);
        Destroy(gameObject);        // 销毁界面

        // 移除界面字典
        if(UIManager.Instance.panelDict.ContainsKey(name))
        {
            UIManager.Instance.panelDict.Remove(name);
        }
    }
}
