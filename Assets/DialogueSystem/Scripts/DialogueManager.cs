using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;
using UnityEngine.Serialization;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;//单例模式,确保唯一性
    public GameObject dialogueBox;//文本框
    public GameObject talkChoiceBox;//对话选项框
    public GameObject talkChoiceStick;//对话选项条

    public TMP_Text nameText, dialogueText;//名字和文本

    private string[] dialogueClips;//对话片段
    private string[] names;//名字
    [SerializeField] private int currentClipIndex;//当前对话的索引值


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

    }

    void Update()
    {
        if (dialogueBox.activeInHierarchy)
        {
            if (Input.GetMouseButtonUp(0))
            {
                currentClipIndex++;
                if (currentClipIndex < dialogueClips.Length)
                {
                    dialogueText.text = dialogueClips[currentClipIndex];
                    nameText.text = names[currentClipIndex];
                }
                else//对话结束，隐藏对话框，恢复角色移动
                {
                    dialogueBox.SetActive(false);
                    talkChoiceBox.SetActive(true);
                    FindObjectOfType<ThirdPersonController>().canMove = true;
                }
            }
        }
    }
    
    //创建对话条
    public GameObject CreateTalkSticks(string name, bool isShow)
    {
        GameObject newTalkStick = Instantiate(talkChoiceStick, Vector3.zero, Quaternion.identity);
        newTalkStick.GetComponentInChildren<TMP_Text>().text = name;
        newTalkStick.SetActive(isShow);
        newTalkStick.transform.SetParent(talkChoiceBox.transform, false);
        return newTalkStick;
    }
    //销毁对话条
    public void DestroyTalkSticks(string name)
    {
        foreach (Transform child in talkChoiceBox.transform)
        {
            if (child.GetComponentInChildren<TMP_Text>().text == name)
            {
                Destroy(child.gameObject);
            }
        }
    }
    //显示对话框
    public void ShowDialogue(string[] newNames, string[] newClips)
    {
        talkChoiceBox.SetActive(false);
        dialogueClips = newClips;
        names = newNames;
        currentClipIndex = 0;
        dialogueText.text = dialogueClips[currentClipIndex];
        nameText.text = names[currentClipIndex];
        dialogueBox.SetActive(true);

        FindObjectOfType<ThirdPersonController>().canMove = false;
    }
}
