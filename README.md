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

| 	QueedDuration(sn)	 | 	ProcessedDuration(sn)	 | 	Cpu(%)	 | Ram(%)	 | IsAsync	 | MIN_CreateDate	 | MAX_CreateDate	 | MIN_QueedDate	 | MAX_QueedDate	 | MIN_ProcessedDate	 | MAX_ProcessedDate	 | TotalProcessedDuration(sn)	 | ProcessedMessageCount_PerSecond	 |
| 	:-----:	 | 	:-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 |	
|0|0|0|50.7512|0|2023-04-11 12:29:16|2023-04-11 12:29:34|2023-04-11 12:29:16|2023-04-11 12:29:34|2023-04-11 12:29:16|	2023-04-11 12:29:34|18|55|
|0|3|0|41.2199|1|2023-04-11 12:24:35|2023-04-11 12:24:43|2023-04-11 12:24:35|2023-04-11 12:24:43|2023-04-11 12:24:37|	2023-04-11 12:24:45|8|125|
											
## 🎉 5000 adet mesaj için
| 	QueedDuration(sn)	 | 	ProcessedDuration(sn)	 | 	Cpu(%)	 | Ram(%)	 | IsAsync	 | MIN_CreateDate	 | MAX_CreateDate	 | MIN_QueedDate	 | MAX_QueedDate	 | MIN_ProcessedDate	 | MAX_ProcessedDate	 | TotalProcessedDuration(sn)	 | ProcessedMessageCount_PerSecond	 |
| 	:-----:	 | 	:-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 |	
|0|0|6.23331|50.9433|0|2023-04-11 12:35:14|2023-04-11 12:36:44|2023-04-11 12:35:14|2023-04-11 12:36:44|2023-04-11 12:35:14|	2023-04-11 12:36:44|90|55|
|0|1|16.2791|82.5638|1|2023-04-11 12:24:59|2023-04-11 12:25:18|2023-04-11 12:24:59|2023-04-11 12:25:18|2023-04-11 12:24:59|	2023-04-11 12:25:18|19|263|

## 🎉 10000 adet mesaj için
| 	QueedDuration(sn)	 | 	ProcessedDuration(sn)	 | 	Cpu(%)	 | Ram(%)	 | IsAsync	 | MIN_CreateDate	 | MAX_CreateDate	 | MIN_QueedDate	 | MAX_QueedDate	 | MIN_ProcessedDate	 | MAX_ProcessedDate	 | TotalProcessedDuration(sn)	 | ProcessedMessageCount_PerSecond	 |
| 	:-----:	 | 	:-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 |	
|0|0|2.93843|51.1618|0|2023-04-11 12:36:59|2023-04-11 12:39:55|2023-04-11 12:36:59|2023-04-11 12:39:55|2023-04-11 12:36:59|	2023-04-11 12:39:55|176|56|
|0|0|15.7932|70.389|1|2023-04-11 12:25:30|2023-04-11 12:26:03|2023-04-11 12:25:30|2023-04-11 12:26:03|2023-04-11 12:25:30|	2023-04-11 12:26:03|33|303|
