# my_net_2  
這次使用ASP.NET Core  

#實作日誌  

Day1  
為了學習ASP.NET一開始我是照著youtube上的教學做的，到了實作第二天要連接資料庫時才發現沒有appsetting，我花了好久的時間才發現原來ASP.NET Core跟ASP.NET Framework是兩個完全不一樣的東西，兩著差異其實蠻大的。  
![asp_net_compare](https://user-images.githubusercontent.com/32414355/143891954-df6a223c-66af-4227-9579-7778ca586af3.png)  
※比較圖  

Day2  
我選擇使用MySQL來實作這次ASP.NET的小專案，但要連結MySQL的看似簡單其實花了我很久的時間去搞懂，包含Model的使用和把資料從appsetting讀出來，我查了很多決定使用在controller寫一個IConfiguration介面
來把他們接起來。 
參考文章:https://dotblogs.com.tw/shadow/2018/09/10/003606  
Day3  
今天使用ASP.NET內建的會員系統identity來實作登入系統，碰上的問題也是超級多，比如預設的資料庫指令是UseSqlServer而不是UseMySql，後來又發現MySQL.Data不支援MySQL.Data.EntityFrameworkCore(Nuget套件)，然後又因為不相容的問題完全不能安裝，最後使用Pomelo 2.1.0(更高版本也不支援...)，最終實作成功，也學會了如何使用Ioption強行別注入。 
ASP.NET各資料庫的提供者指令參考:https://docs.microsoft.com/zh-tw/ef/core/providers/?tabs=dotnet-core-cli  
