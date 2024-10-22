# 基于Excel的对话系统

![截屏2024-10-06 18.59.06.png](%E5%9F%BA%E4%BA%8EExcel%E7%9A%84%E5%AF%B9%E8%AF%9D%E7%B3%BB%E7%BB%9F%20117b58d050e380c2a071cd7f02fb8819/%25E6%2588%25AA%25E5%25B1%258F2024-10-06_18.59.06.png)

这个对话系统的核心是DialogueCanvas预制体和Talkable脚本。

挂载在DialogueCanvas上的Dialogue Manager脚本负责管理UI交互逻辑，而Talkable脚本则负责读取后缀为.xlsx的Excel表格中的对话文本，并通过名称标识可对话的对象。这两个脚本分工合作，共同实现了整个对话系统的运行逻辑：

1. 玩家进入可对话对象的触发器范围
2. 显示选项条UI
3. 按下对话交互键（项目设置为F键或鼠标左键点击选项条）
4. 系统通过对话框展示可对话对象的文本
5. 点击进入下一句对话
6. 文本全部读完后，关闭UI显示

使用指南：要使用此对话系统，游戏场景中必须存在DialogueCanvas对象。如需扩展Canvas内部、增加其他系统的UI，可以在原有基础上新建Panel。对话系统的UI应放在对话系统的Panel下，商店系统的UI则放在商店系统的Panel下。

Talkable即可对话对象。每个可对话对象都应挂载此脚本，并为对话选项条UI设置合适的显示名称，同时指定包含对话内容的.xlsx表格文件。表格格式如下：

![image.png](%E5%9F%BA%E4%BA%8EExcel%E7%9A%84%E5%AF%B9%E8%AF%9D%E7%B3%BB%E7%BB%9F%20117b58d050e380c2a071cd7f02fb8819/image.png)
