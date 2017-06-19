## 付呗生活圈开放平台公众号支付demo

### 项目简介
该项目基于ASP.NET core MVC 1.1框架开发，实现了付呗生活圈开放平台的公众号授权、支付、回调通知等业务逻辑。点击查看[付呗生活圈开放平台接口文档](apihttps://www.gitbook.com/book/fubei/lifecircleopen-api)

#### 项目依赖
>* .Net Core 1.0
>* Asp.Net Core 1.1
>* Asp.Net Core MVC 1.1
>* Swagger ASP.Net Core 1.0

Asp.net Core相关文档见[Asp.Net Core官方网站](https://docs.microsoft.com/en-us/aspnet/core/)

### 环境配置与搭建说明
#### 开发环境安装
##### .Net Core 安装
访问[.Net Core官网下载页面](https://www.microsoft.com/net/download/core)安装对应平台的.Net Core SDK

###### Windows 7
如果您使用**Windows 7**系统作为您的开发/部署环境，请安装微软补丁[Windows6.1-KB2533623-x64](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remote-code-execution)，否则会因权限不足无法编译和运行.Net Core程序。

###### 安装Mono（非Windows系统）
访问[Mono Project官网](http://www.mono-project.com/download/#download-lin)，并按照提示安装Mono运行时

##### 安装Asp.Net Core （Linux系统，Windows/OSX系统可跳过）
Linux系统环境下，Asp.Net Core并不包含在mono-devel中，需要另外安装。
**Ubuntu/Debian**
``` bash
$ sudo apt install mono-xsp4
```
**RHEL/Fedora/CentOS** （根据系统版本选择yum或者dnf安装）
``` bash
# 安装asp.net core 4（yum方式）
$ sudo yum install mono-xsp4 -y
# 安装asp.net core 4（dnf方式）
$ sudo dnf install mono-xsp4 -y
```

##### 安装git并下载DEMO源码
访问[Git官网](https://git-scm.com/downloads)安装git scm，安装完成后，运行git clone下载源码
``` bash
$ git clone https://github.com/hz-zentech/fubei-aspnetcore-demo.git
```
##### 设置开发模式（可选）
该项目支持的IDE为：
> * [Visual Studio 2017](https://www.visualstudio.com/downloads/)
> * [Rider 2017](https://www.jetbrains.com/rider/)
> * [Visual Studio Code](https://code.visualstudio.com/)

IDE调试时，默认为生成环境，无法调试本项目，如需对调试源码，需按如下方式启动开发模式，具体可参考[StackOverflow #38273596](https://stackoverflow.com/questions/38273596/net-core-project-json-commands-set-aspnetcore-environment)，开发模式下，加载的配置文件为`appsettings.Development.json`。
###### **Visual Studio**下调试
`项目属性`->`调试`->`环境变量`
添加ASPNETCORE_ENVIRONMENT=Development
或者添加参数：dotnet run --ASPNETCORE_ENVIRONMENT Development
![Alt text](./readme/1497869481800.png)

###### **Rider**下调试
打开`Run/Debug Configuration`->`.Net Project`->`Default`->`Environment vaiables`，添加ASPNETCORE_ENVIRONMENT=Development
![Alt text](./readme/1497869624008.png)

##### 修改付呗回调地址与项目配置文件
访问付呗接口配置页面http://sh.51youdian.com/User/OpenApiConfig/detail（需登录），并将回调地址配成 **http://域名/notify**
![Alt text](./1497886147121.png)

之后请修改appsettings.json/appsettings.Development.json文件中的ApplicationConfiguration节，修改AppId和AppSecret为从生活圈文档中获得的AppId和AppSecret

##### 编译并运行Demo
此时Demo即可编译运行，也可切到项目路径中，运行dotnet restore命令初始化依赖库
``` bash
# 安装项目依赖
$ dotnet restore
# 编译并运行
$ dotnet run
```

##### NuGet国内源配置（可选）
修改Nuget.Config
**Windows**   %AppData%/NuGet/Nuget.Config
**OSX/Linux** ~/.nuget/NuGet/Nuget.Config
``` xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
	<!-- cnlogs国内nuget镜像 -->
    <add key="nuget.cnblogs.com" value="https://nuget.cnblogs.com/v3/index.json" protocolVersion="3" />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
  </packageSources>
</configuration>
```


### 核心类说明
#### 工具类
> **FubeiDemoMvcApplication.Common.FubeiSignatureUtil**
> 付呗签名计算/签名验证工具

> **FubeiDemoMvcApplication.Common.HttpUtil**
> 付呗api http接口请求类

#### 控制器
> **FubeiDemoMvcApplication.Controllers.AuthController**
> 认证接口控制器
> 
> **FubeiDemoMvcApplication.Controllers.NotifyController**
> 通知接口控制器
>
> **FubeiDemoMvcApplication.Controllers.OrderController**
> 订单接口控制器

#### 服务类
> **FubeiDemoMvcApplication.Services.IFubeiApiRequestService**
> 付呗Api请求服务
> 
> **FubeiDemoMvcApplication.Services.IFubeiSignatureSerivce**
> 付呗签名服务 
>
> **FubeiDemoMvcApplication.Services.IOrderService**
> 付呗订单服务

### 部署说明
Asp.Net Core部署说明可参考文档[.NET Core application deployment
](https://docs.microsoft.com/en-us/dotnet/core/deploying/index)
#### 打包
`VisualStudio`：
选中需要打包的项目，点击`“生成”`->`“发布”`方式进行打包

`命令行`：
在项目路径下，使用以下命令进行打包
``` bash
$ dotnet publish -f netcoreapp1.1 -c Release
```
生成项目路径为：bin\Release\netcoreapp1.1\publish

#### 以FDD（Framework-dependent deployments）方式部署
这种部署机制和传统的.NET Framework相似，只要目标平台上存在.NET Core Runtime即可。如需以IIS作为承载方式，需下载 [.NET Core Windows Server Hosting](https://go.microsoft.com/fwlink/?linkid=844461)，新建站点后，设置应用程序池为：无托管代码方式
![Alt text](./1497873675861.png)

#### 以SCD（Self-contained deployments）方式部署
这种部署机制将应用和运行时共同打包，即便目标平台上没有安装.NET Core Runtime也能正常使用。
##### 增加RuntimeIdentifiers配置
修改项目所在文件.csproj，找到Project.PropertyGroup.RuntimeIdentifiers节，增加需要打包的系统环境，如：win7-x64，ubuntu.16.04-x64，支持的RID见[.NET Core Runtime IDentifier (RID) catalog](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog)
##### 打包
以Ubuntu 16.04为例：
``` bash
$ dotnet publish -c Release -r ubuntu.16.04-x64
```
##### 运行
``` bash
# 进入publish目录
$ cd bin/Release/netcoreapp1.1/ubuntu.16.04-x64/publish
# 增加可执行权限
$ chmod +x FubeiDemoMvcApplication
# 运行
$ ./FubeiDemoMvcApplication
```





