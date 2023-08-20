# WorkflowExecutor
基于workflow core的workflow微服务。

目标是使用 Workflow-Core 作为 workflow enging，实现基于 json 配置文件的动态 workfolw 执行功能。
目前架构是
  - 后端微服务用 Asp.Net core WebApi
  - 前端框架 Augular + MaterialDegisn

主要思想是通过前端拖拽的操作方式，组合预先定义好的workflow step，然后生成 json 配置文件，然后让后端服务读取生成的配置文件，然后开始运行 workflow。
