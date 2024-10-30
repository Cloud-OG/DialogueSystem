using UnityEngine;
using System.IO;
using OfficeOpenXml;
using UnityEditor;
using UnityEngine.UI;

public class Talkable : MonoBehaviour
{
    [SerializeField] private bool isEntered;
    public string objectName;//对象名，用于可对话提示
    private string[] NameClips;//名字片段
    private string[] dialogueClips;//对话片段
    private bool talkSticksCreated = false; // 是否创建过对话选项
    public Object excelFile; // xlsx文件对象

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isEntered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isEntered = false;
        }
    }



    void Start()
    {
         // 获取文件的相对路径
        string filePath = AssetDatabase.GetAssetPath(excelFile);
        ReadXML(filePath, 3, 4);
    }
    
    //通过文件路径，名字所在列索引，对话所在列索引读取XML文件
    public void ReadXML(string filePath, int nameCloumnIndex, int dialogueCloumnIndex)
    {
        //获取Excel文件的信息
        FileInfo fileInfo = new FileInfo(filePath);

        //通过Excel表格的文件信息，打开Excel表格
        using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
        {
            //取得Excel文件中的第一张表
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[1];
            NameClips = new string[worksheet.Dimension.End.Row-1];
            dialogueClips = new string[worksheet.Dimension.End.Row-1];

            // 跳过表头
            for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
            {
                // 检查单元格是否为空
                var nameCellValue = worksheet.Cells[i, nameCloumnIndex].Value;
                var dialogueCellValue = worksheet.Cells[i, dialogueCloumnIndex].Value;

                // 如果单元格值为空，给它一个默认值或者跳过这个单元格
                if (nameCellValue != null || dialogueCellValue != null)
                {
                    NameClips[i - 2] = nameCellValue.ToString();
                    dialogueClips[i - 2] = dialogueCellValue.ToString();
                }
                else
                {
                    // 处理空单元格的情况，可以设置默认值或跳过
                    return;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isEntered)
        {
            if (Input.GetKeyDown(KeyCode.F) && DialogueManager.instance.dialogueBox.activeInHierarchy == false)
            {
                DialogueManager.instance.ShowDialogue(NameClips, dialogueClips);
            }
            else
            {
                if (!talkSticksCreated) // 只有在没有创建过的情况下才创建对话选项
                {
                    GameObject talkStick = DialogueManager.instance.CreateTalkSticks(objectName, !DialogueManager.instance.dialogueBox.activeInHierarchy);
                    talkStick.GetComponent<Button>().onClick.AddListener(() => { DialogueManager.instance.ShowDialogue(NameClips, dialogueClips); });
                    talkSticksCreated = true; // 标记为已创建
                }
            }
        }
        else
        {
            if (talkSticksCreated) // 如果之前创建过，则在离开时销毁对话选项
            {
                DialogueManager.instance.DestroyTalkSticks(objectName); // 假设你有一个销毁对话选项的方法
                talkSticksCreated = false; // 重置标记
            }
        }
    }
}
