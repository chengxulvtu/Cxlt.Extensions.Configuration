# Cxlt.Extensions.Configuration

该项目包含两个Provider的实现。

## Cxlt.Extensions.Configuration.EF

这个Provider使用Entity Framework Core框架，可以把配置存储在数据库中，SQL Server、MySQL、SQLite等都可以。

我专门写了一篇文章，讲解这个Provider的实现过程。

[实现自己的.NET Core配置Provider之EF](http://www.chengxulvtu.com/2017/06/29/custom-net-core-configuration-provider-for-ef.html)

包的使用方式
```bash
Install-Package Cxlt.Extensions.Configuration.EF
```
或
```bash
dotnet add package Cxlt.Extensions.Configuration.EF
```

## Cxlt.Extensions.Configuration.Yaml

Yaml是很多大型开源项目都使用的配置文件格式，本项目实现了在.NET Core程序中读取Yaml文件配置，详细的实现过程可以参考下面的文章。

[实现自己的.NET Core配置Provider之Yaml](http://www.chengxulvtu.com/2017/06/29/custom-net-core-configuration-provider-for-yaml.html)

包的使用方式
```bash
Install-Package Cxlt.Extensions.Configuration.Yaml
```
或
```bash
dotnet add package Cxlt.Extensions.Configuration.Yaml
```


