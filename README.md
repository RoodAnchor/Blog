# Blog

## Логирование NLog
NLog пишет в БД, так что результаты можно посмотреть на странице /Logs

## API
Blog.API ссылается на тот же blog.db файл, что и Blog.Presentation т.е. Blog.Presentation\bin\Debug\net8.0\DB. Так что можно запускать оба проекта параллельно и следить за изменениями (прилетающими от API) в UI