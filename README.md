# Compare Thread&amp;Task
Veriler oluşturulurken iş parçacığının veriyi işlemesi ile veritabanına aktarılması arasına 10 ms bekleme süresi konulmuştur. Tablodaki tarih verileri runtime'da oluşturulan tarih verileridir. Mesajların veritabanına eklenme zamanları tabloya dahil edilmemiştir.
## ✨ Mimari
 <p align="center"><img src="https://raw.githubusercontent.com/hasanaxan/ConsumerTest/master/consumer-mimari.png" alt="demo" width=80%></p>

## 💎 Veri Açıklamaları
 - QueedDuration: Mesajın oluşturulduğu andan iş parçacığı güvenli mesaj listesine atılmasına kadar geçen ortalama süre.
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
 
## 🎉 1000 adet mesaj için

| 	QueedDuration(sn)	 | 	ProcessedDuration(sn)	 | 	Cpu(msn)	 | Ram(MB)	 | IsAsync	 | MIN_CreateDate	 | MAX_CreateDate	 | MIN_QueedDate	 | MAX_QueedDate	 | MIN_ProcessedDate	 | MAX_ProcessedDate	 | TotalProcessedDuration(sn)	 | ProcessedMessageCount_PerSecond	 |
| 	:-----:	 | 	:-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 |	
|0|0|6.04478|47.7959|0|2023-04-15 22:42:52|2023-04-15 22:43:05|2023-04-15 22:42:52|2023-04-15 22:43:05|2023-04-15 22:42:53|	2023-04-15 22:43:05|12|83|
|0|2|2.33907|43.5562|1|2023-04-15 22:50:28|2023-04-15 22:50:33|2023-04-15 22:50:28|2023-04-15 22:50:33|2023-04-15 22:50:28|	2023-04-15 22:50:34|6|166|
											
## 🎉 5000 adet mesaj için
| 	QueedDuration(sn)	 | 	ProcessedDuration(sn)	 | 	Cpu(msn)	 | Ram(MB)	 | IsAsync	 | MIN_CreateDate	 | MAX_CreateDate	 | MIN_QueedDate	 | MAX_QueedDate	 | MIN_ProcessedDate	 | MAX_ProcessedDate	 | TotalProcessedDuration(sn)	 | ProcessedMessageCount_PerSecond	 |
| 	:-----:	 | 	:-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 |	
|0|0|30.2051|44.5147|0|2023-04-15 23:05:37|2023-04-15 23:06:22|2023-04-15 23:05:37|2023-04-15 23:06:22|2023-04-15 23:05:37|	2023-04-15 23:06:22|45|111|
|0|0|16.0311|60.072|1|2023-04-15 23:04:56|2023-04-15 23:05:11|2023-04-15 23:04:56|2023-04-15 23:05:11|2023-04-15 23:04:56|	2023-04-15 23:05:11|15|333|

## 🎉 10000 adet mesaj için
| 	QueedDuration(sn)	 | 	ProcessedDuration(sn)	 | 	Cpu(msn)	 | Ram(MB)	 | IsAsync	 | MIN_CreateDate	 | MAX_CreateDate	 | MIN_QueedDate	 | MAX_QueedDate	 | MIN_ProcessedDate	 | MAX_ProcessedDate	 | TotalProcessedDuration(sn)	 | ProcessedMessageCount_PerSecond	 |
| 	:-----:	 | 	:-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 |	
|0|0|36.6518|44.1463|0|2023-04-15 23:09:14|2023-04-15 23:10:42|2023-04-15 23:09:14|2023-04-15 23:10:42|2023-04-15 23:09:14|	2023-04-15 23:10:42|88|113|
|0|0|18.2937|70.0385|1|2023-04-15 23:11:59|2023-04-15 23:12:29|2023-04-15 23:11:59|2023-04-15 23:12:29|2023-04-15 23:11:59|	2023-04-15 23:12:29|30|333|
