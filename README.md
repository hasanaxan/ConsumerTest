# Compare Thread&amp;Task
Veriler oluşturulurken iş parçacığının veriyi işlemesi ile veritabanına aktarılması arasına 10 ms bekleme süresi konulmuştur. Tablodaki tarih verileri runtime'da oluşturulan tarih verileridir. Mesajların veritabanına eklenme zamanları tabloya dahil edilmemiştir.
## ✨ Mimari
 <p align="center"><img src="https://raw.githubusercontent.com/hasanaxan/ConsumerTest/master/consumer-mimari.png" alt="demo" width=80%></p>

## 💎 Veri Açıklamaları
 - ThreadCountAvg: Ortalama iş parçacığı sayısı.
 - ProcessedDuration: Mesasın listeye atılması ile işlenmesi arasında geçen süre.
 - IsAsync: 0 için Thread, 1 için Task 
 - MIN_CreateDate: En erken oluşturulan mesajın tarihi
 - MAX_CreateDate: En geç oluşturulan mesajın tarihi
 - MIN_QueedDate: Mesajın en erken kuyruğa atılma tarihi
 - MAX_QueedDate: Mesajın en geç kuyruğa atılma tarihi
 - MIN_ProcessedDate: En erken işlenen mesaj tarihi
 - MAX_ProcessedDate: En geç işlenen mesaj tarihi
 - TotalProcessedDuration: Mesaj kuyruğundaki verilen işlenmesi için geçen toplam süre
 - ProcessedMessageCount_PerSecond: 1 sn işlenen ortalama mesaj adeti
 
## 🎉 5000 adet mesaj için

| 	ThreadCountAvg	 | 	ProcessedDuration(sn)	 | 	Cpu(msn)	 | Ram(MB)	 | IsAsync	 | IsParallel	 | MIN_CreateDate	 | MAX_CreateDate	 | MIN_QueedDate	 | MAX_QueedDate	 | MIN_ProcessedDate	 | MAX_ProcessedDate	 | TotalProcessedDuration(sn)	 | ProcessedMessageCount_PerSecond	 |
| 	:-----:	 | 	:-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 |	
|0|0|5.27872|33.1949|0|0|2023-05-17 11:07:11|2023-05-17 11:07:11|2023-05-17 11:07:24|2023-05-17 11:08:45|2023-05-17 11:07:24|	2023-05-17 11:08:45|81|61|
|6|0|236.273|39.2068|0|1|2023-05-17 11:03:48|2023-05-17 11:03:48|2023-05-17 11:04:04|2023-05-17 11:04:18|2023-05-17 11:04:04|	2023-05-17 11:04:18|14|357|
|13|0|0|61.9182|1|0|2023-05-17 11:18:44|2023-05-17 11:18:44|2023-05-17 11:18:47|2023-05-17 11:18:54|2023-05-17 11:18:47|	2023-05-17 11:18:54|7|714|
											
## 🎉 10000 adet mesaj için
| 	ThreadCountAvg	 | 	ProcessedDuration(sn)	 | 	Cpu(msn)	 | Ram(MB)	 | IsAsync	 | IsParallel	 | MIN_CreateDate	 | MAX_CreateDate	 | MIN_QueedDate	 | MAX_QueedDate	 | MIN_ProcessedDate	 | MAX_ProcessedDate	 | TotalProcessedDuration(sn)	 | ProcessedMessageCount_PerSecond	 |
| 	:-----:	 | 	:-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 |	
|0|0|6.20085|34.241|0|0|2023-05-17 11:09:17|2023-05-17 11:09:17|2023-05-17 11:09:19|2023-05-17 11:12:02|2023-05-17 11:09:19|	2023-05-17 11:12:02|163|61|
|9|0|132.125|40.7338|0|1|2023-05-17 11:04:29|2023-05-17 11:04:29|2023-05-17 11:04:30|2023-05-17 11:04:53|2023-05-17 11:04:30|	2023-05-17 11:04:53|23|434|
|15|0|14.7586|56.8839|1|0|2023-05-17 11:19:02|2023-05-17 11:19:02|2023-05-17 11:19:05|2023-05-17 11:19:19|2023-05-17 11:19:05|	2023-05-17 11:19:19|14|714|

## 🎉 20000 adet mesaj için
| 	ThreadCountAvg	 | 	ProcessedDuration(sn)	 | 	Cpu(msn)	 | Ram(MB)	 | IsAsync	 | IsParallel	 | MIN_CreateDate	 | MAX_CreateDate	 | MIN_QueedDate	 | MAX_QueedDate	 | MIN_ProcessedDate	 | MAX_ProcessedDate	 | TotalProcessedDuration(sn)	 | ProcessedMessageCount_PerSecond	 |
| 	:-----:	 | 	:-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 |	
|0|0|11.9663|36.3223|0|0|2023-05-17 11:12:52|2023-05-17 11:12:52|2023-05-17 11:12:54|2023-05-17 11:18:25|2023-05-17 11:12:54|	2023-05-17 11:18:25|331|60|
|13|0|87.9506|43.641|0|1|2023-05-17 11:05:08|2023-05-17 11:05:08|2023-05-17 11:05:12|2023-05-17 11:05:48|2023-05-17 11:05:12|	2023-05-17 11:05:48|36|555|
|16|0|11.2632|57.1182|1|0|2023-05-17 11:19:30|2023-05-17 11:19:30|2023-05-17 11:19:31|2023-05-17 11:20:00|2023-05-17 11:19:31|	2023-05-17 11:20:00|29|689|
