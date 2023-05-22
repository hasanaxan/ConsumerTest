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
| 	:-----:	 | 	:-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 |	
|0|0|5.27872|33.1949|0||0||0|2023-05-17 11:07:11|2023-05-17 11:07:11|2023-05-17 11:07:24|2023-05-17 11:08:45|2023-05-17 11:07:24|	2023-05-17 11:08:45|81|61|
|6|0|236.273|39.2068|0||1||6|2023-05-17 11:03:48|2023-05-17 11:03:48|2023-05-17 11:04:04|2023-05-17 11:04:18|2023-05-17 11:04:04|	2023-05-17 11:04:18|14|357|
|13|0|0|61.9182|1||0||13|2023-05-17 11:18:44|2023-05-17 11:18:44|2023-05-17 11:18:47|2023-05-17 11:18:54|2023-05-17 11:18:47|	2023-05-17 11:18:54|7|714|
											
## 🎉 10000 adet mesaj için
| 	ThreadCountAvg	 | 	ProcessedDuration(sn)	 | 	Cpu(msn)	 | Ram(MB)	 | IsAsync| IsParallel	 | MIN_CreateDate	 | MAX_CreateDate	 | MIN_QueedDate	 | MAX_QueedDate	 | MIN_ProcessedDate	 | MAX_ProcessedDate	 | TotalProcessedDuration(sn)	 | ProcessedMessageCount_PerSecond	 |
| 	:-----:	 | 	:-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 |	
|0|0|30.2051|44.5147|0|2023-04-15 23:05:37|2023-04-15 23:06:22|2023-04-15 23:05:37|2023-04-15 23:06:22|2023-04-15 23:05:37|	2023-04-15 23:06:22|45|111|
|0|0|16.0311|60.072|1|2023-04-15 23:04:56|2023-04-15 23:05:11|2023-04-15 23:04:56|2023-04-15 23:05:11|2023-04-15 23:04:56|	2023-04-15 23:05:11|15|333|

## 🎉 20000 adet mesaj için
| 	ThreadCountAvg	 | 	ProcessedDuration(sn)	 | 	Cpu(msn)	 | Ram(MB)	 | IsAsync | IsParallel	 | MIN_CreateDate	 | MAX_CreateDate	 | MIN_QueedDate	 | MAX_QueedDate	 | MIN_ProcessedDate	 | MAX_ProcessedDate	 | TotalProcessedDuration(sn)	 | ProcessedMessageCount_PerSecond	 |
| 	:-----:	 | 	:-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 |	
|0|0|36.6518|44.1463|0|2023-04-15 23:09:14|2023-04-15 23:10:42|2023-04-15 23:09:14|2023-04-15 23:10:42|2023-04-15 23:09:14|	2023-04-15 23:10:42|88|113|
|0|0|18.2937|70.0385|1|2023-04-15 23:11:59|2023-04-15 23:12:29|2023-04-15 23:11:59|2023-04-15 23:12:29|2023-04-15 23:11:59|	2023-04-15 23:12:29|30|333|
