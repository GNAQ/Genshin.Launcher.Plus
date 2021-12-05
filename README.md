# 原神启动器Plus

### 说明：（请认真阅读）

1. 注意，国际服切换和保存用户凭证涉及到注册表修改和文件替换，部分杀毒软件可能会报毒，为了客户端数据完整建议关闭杀软后再运行本启动器完全开源，并不会将用户数据发送到网络，启动器需要联网部分的代码仅为版本检测和公告获取【1.0.5修正】

2. 本启动器使用到的修复SDK的资源为B站官方客户端中提取的DLL，用途是启动游戏后的B站专属登录窗口，如果不信任可以不使用或者自行寻找同名资源替换【图片1.0.4修正】
   
   
   
   ***==>【专门找了个盘又双叒叕重新下了两个服的文件来对比】***
   ![SDK.png](https://i.loli.net/2021/11/28/o9wAXPevT5i6WbG.png)
   
   #### 修复SDK的dll文件PCGameSDK.dll[本文件仅为B站端的时候起作用]的Hash值：
   
   ```html
   [MD5:81EE1D7755B8611AC98B334E0BBCD3D2]
   ```
   ```html
   [SHA256:88030B01A9E2B4A1032DEA3FA8A17DF30C8AEB5A7614F1CFA02C898C5B4371EA]
   ```
   
3. 本启动器使用的国际服资源包[GlobalFile.pkg]为国际服与国服使用Beyond Compare对比提取后进行打包，实际为zip格式文件，如不信任可以不使用



### 主界面：（模仿官方大小排布设计）

![启动器.png](https://i.loli.net/2021/11/28/6QpbUeyx3NzSFOa.png)

#### 点击右侧图片样式的按钮支持快速直达游戏内保存的相片/截图目录

支持自定义启动器背景：将1280×730分辨率（或同等比例）的png格式图片改名bg.png放置Config目录下打开启动器即可

### 设置界面：
![设置.png](https://i.loli.net/2021/11/28/EvCqzKZw8VymDtb.png)
支持选择B服、官服、国际服和自定义任意分辨率启动，后期可能加入解锁FPS限制的选项（鸽~~)  

![读取.png](https://i.loli.net/2021/11/28/P1qudJzIs7yij4k.png)

保存上次（现在）登录的账号数据到UserData文件夹中以快速切换账号。

注意：名字输入框里勿填以下符号：   \ / : * ? " < > |    否则可能会出现问题






## 版本更新：
### 1.0.1

1. 启动器首次发布  

### 1.0.2

1. 修复游戏安装在系统盘的权限问题
2. 增加了首次官服转换哔哩哔哩服游戏
   提示MihoyoSDK未初始化报错的解决方法

### 1.0.3

1. 增加了启动器版本更新功能
2. 整合了mihoyosdk的文件至启动器
3. 增加了对国际服的切换支持【需下载切换资源包GlobalFile.pkg】
   资源包下载地址：[下载资源包](https://pan.baidu.com/s/1-5zQoVfE7ImdXrn8OInKqg) 访问密码：etxd

### 1.0.4

1. 修复转换国际服后游戏报错31-4302
2. 优化了对哔哩哔哩端SDK文件的检测方式
3. 增加了对pkg包的版本检测以便大版本更新时提示

### 1.0.5

1. 增加了账号快速切换启动的功能[不支持哔哩端]
2. 修复了1.0.4加入国际服转换后读取哔哩服和官服失效
3. 修复了原本是哔哩哔哩端切换到官服登录错误
4. 优化了代码结构，删除冗余代码（误）

### 1.0.6

1. 大幅优化切换国际服的代码逻辑
2. 优化切换国际服时线程占用导致UI卡顿
3. 修复切换国际服/还原国服时替换文件概率闪退的问题
   （如果还是会那就是杀软问题或者自己手动改了什么文件造成的了）
4. 更正和增加一些使用时的提示和警告文案

### 1.0.7

1. 增加了常用分辨率快速选择
2. 设置中增加了无边框启动的选项
3. 修改了游戏路径输入框的文案
   [填入的路径应为官方启动器路径，若游戏不在启动器路径下应填为游戏的上一级目录路径]
4. 优化了设置界面，现支持随意拖动

### 1.0.8

1. 增加了解锁FPS帧率上限的选项
2. 改进了取分辨率的逻辑和增加4K选项
3. 优化了启动器主页右边按钮的Tab切换顺序
4. 修改和增加了一些提示和警告文案

### 1.0.8.5

1. 修复解锁FPS帧率启动时报错缺少dll
2. 修复一些人设置界面会出现UI渲染错误
3. 修复首次打开设置界面目录填写框显示false
4. 解锁FPS帧率限制现在最高支持到160上限
5. 主界面左下角增加了跳转到[使用教程视频]的按钮

### 1.0.9

1. 设置界面布局大小做了微调
2. 增加自定义解锁的FPS上限输入框
3. 修复选择解锁FPS后全屏无法启动游戏



## 代码引用&参考

读写注册表原神账户数据：[genshin-account](https://github.com/babalae/genshin-account)

解锁FPS：[genshin-fps-unlock](https://gitee.com/Euphony_Facetious/genshin-fps-unlock)




## [点击下载](https://github.com/DawnFz/Genshin-LauncherDIY/releases)
#### ~~提示：1.0.2版本为纯脱机程序，没有加入更新功能，预计下个版本加入。~~

### 正在准备的功能：

1. 官服转换哔哩哔哩服[完成]
2. 修复MihoyoSDK缺失【PCGameSDK.dll】[完成]
3. 增加对国际服的支持[完成]
4. 保存上一个用户凭证注册表，以便选择快速登录[完成]
4. 启动游戏时可选解锁FPS限制[完成]
4. 快捷键呼出照相截图保存目录[制作中]

其他待补充  
