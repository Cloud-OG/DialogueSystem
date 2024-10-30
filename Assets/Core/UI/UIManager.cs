using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager
{
    // 单例模式
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UIManager();
            }
            return instance;
        }
    }

    // 路径配置字典
    private Dictionary<string, string> pathDict;

    // 私有构造函数，确保只能通过单例访问
    private UIManager()
    {
        InitDicts();
    }

    /// <summary>
    /// 初始化路径配置字典
    /// </summary>
    private void InitDicts()
    {
        pathDict = new Dictionary<string, string>
        {
            { UIConst.MainMenuPanel, "UI/MainMenuPanel" },
            { UIConst.OptionsPanel, "UI/OptionsPanel" }
        };
        prefabDict = new Dictionary<string, GameObject>();
        panelDict = new Dictionary<string, BasePanel>();

    }

    private Transform uiRoot;

    // UI根节点
    public Transform UIRoot
    {
        get
        {
            if (uiRoot == null)
            {
                uiRoot = GameObject.Find("Canvas").transform;
            }
            return uiRoot;
        }
    }

    // 预制件缓存字典
    private Dictionary<string, GameObject> prefabDict;
    public Dictionary<string, BasePanel> panelDict;


    /// <summary>
    /// 打开界面
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public BasePanel OpenPanel(string name)
    {
        BasePanel panel = null;
        // 检查是否已打开
        if (panelDict.TryGetValue(name, out panel))
        {
            Debug.LogError("界面已打开: " + name);
            return null;
        }

        // 检查路径是否配置
        string path = "";
        if (!pathDict.TryGetValue(name, out path))
        {
            Debug.LogError("界面名称错误，或未配置路径: " + name);
            return null;
        }

        // 使用缓存预制件
        GameObject panelPrefab = null;
        if (!prefabDict.TryGetValue(name, out panelPrefab))
        {
            string realPath = "Prefab/Panel/" + path;
            panelPrefab = Resources.Load<GameObject>(realPath) as GameObject;
            prefabDict.Add(name, panelPrefab);
        }

        // 打开界面
        GameObject panelObject = GameObject.Instantiate(panelPrefab, UIRoot, false);
        panel = panelObject.GetComponent<BasePanel>();
        panelDict.Add(name, panel);
        panel.OpenPanel(name);
        return panel;
    }

    /// <summary>
    /// 关闭界面
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public bool ClosePanel(string name)
    {
        BasePanel panel = null;
        if (!panelDict.TryGetValue(name, out panel))
        {
            Debug.LogError("界面未打开: " + name);
            return false;
        }

        panel.ClosePanel();
        return true;
    }
}