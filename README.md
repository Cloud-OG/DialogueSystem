# DialogueSystem
Unity对话系统
![截屏2024-10-06 18.59.06.png](https://prod-files-secure.s3.us-west-2.amazonaws.com/62ea150e-ff98-40ae-986e-7a386289383f/41e4d66a-7449-44b4-9e5b-b01434300871/%E6%88%AA%E5%B1%8F2024-10-06_18.59.06.png)

这个对话系统的核心是DialogueCanvas预制体和Talkable脚本。

挂载在DialogueCanvas上的Dialogue Manager脚本负责管理UI交互逻辑，而Talkable脚本则负责读取后缀为.xlsx的Excel表格中的对话文本，并通过名称标识可对话的对象。这两个脚本分工合作，共同实现了整个对话系统的运行逻辑：

1. 玩家进入可对话对象的触发器范围
2. 显示选项条UI
3. 按下对话交互键（项目设置为F键或鼠标左键点击选项条）
4. 系统通过对话框展示可对话对象的文本
5. 点击进入下一句对话
6. 文本全部读完后，关闭UI显示

![image.png](https://prod-files-secure.s3.us-west-2.amazonaws.com/62ea150e-ff98-40ae-986e-7a386289383f/81271614-47e0-4ec2-9595-a5ff8a5c6d64/image.png)

![image.png](https://prod-files-secure.s3.us-west-2.amazonaws.com/62ea150e-ff98-40ae-986e-7a386289383f/73300382-c63a-459f-a465-f38e6b21556a/image.png)

使用指南：要使用此对话系统，游戏场景中必须存在DialogueCanvas对象。如需扩展Canvas内部、增加其他系统的UI，可以在原有基础上新建Panel。对话系统的UI应放在对话系统的Panel下，商店系统的UI则放在商店系统的Panel下。

Talkable即可对话对象。每个可对话对象都应挂载此脚本，并为对话选项条UI设置合适的显示名称，同时指定包含对话内容的.xlsx表格文件。表格格式如下：

![image.png](https://prod-files-secure.s3.us-west-2.amazonaws.com/62ea150e-ff98-40ae-986e-7a386289383f/0b76da97-be8d-4af4-a9fc-1ebbab33d44c/image.png)
