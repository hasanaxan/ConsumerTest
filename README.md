# Compare Thread&amp;Task
Veriler oluşturulurken iş parçacığının veriyi işlemesi ile veritabanına aktarılması arasına 10 ms bekleme süresi konulmuştur. Tablodaki tarih verileri runtime'da oluşturulan tarih verileridir. Mesajların veritabanına eklenme zamanları tabloya dahil edilmemiştir.
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
 <p align="center"><img src="https://raw.githubusercontent.com/hasanaxan/ConsumerTest/master/consumer-mimari.png" alt="demo" width=80%></p>
 
## 🎉 1000 adet mesaj için

| 	QueedDuration(sn)	 | 	ProcessedDuration(sn)	 | 	Cpu(%)	 | Ram(%)	 | IsAsync	 | MIN_CreateDate	 | MAX_CreateDate	 | MIN_QueedDate	 | MAX_QueedDate	 | MIN_ProcessedDate	 | MAX_ProcessedDate	 | TotalProcessedDuration(sn)	 | ProcessedMessageCount_PerSecond	 |
| 	:-----:	 | 	:-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 |	
|12|0|62.1097|86.053|0|2023-03-27 22:09:50|2023-03-27 22:09:50|2023-03-27 22:09:54|2023-03-27 22:10:11|2023-03-27 22:09:54|	2023-03-27 22:10:11|17|58|
|2|1|100|85.7067|1|2023-03-27 22:10:30|2023-03-27 22:10:30|2023-03-27 22:10:32|2023-03-27 22:10:33|2023-03-27 22:10:32|	2023-03-27 22:10:36|4|250|
											
## 🎉 5000 adet mesaj için
| 	QueedDuration(sn)	 | 	ProcessedDuration(sn)	 | 	Cpu(%)	 | Ram(%)	 | IsAsync	 | MIN_CreateDate	 | MAX_CreateDate	 | MIN_QueedDate	 | MAX_QueedDate	 | MIN_ProcessedDate	 | MAX_ProcessedDate	 | TotalProcessedDuration(sn)	 | ProcessedMessageCount_PerSecond	 |
| 	:-----:	 | 	:-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 |	
|43|0|54.6043|89.8958|0|2023-03-27 22:47:58|2023-03-27 22:47:58|2023-03-27 22:47:59|2023-03-27 22:49:21|2023-03-27 22:47:59|	2023-03-27 22:49:21|82|60|
|5|6|99.9167|89.8562|1|2023-03-27 22:47:24|2023-03-27 22:47:24|2023-03-27 22:47:26|2023-03-27 22:47:33|2023-03-27 22:47:26|	2023-03-27 22:47:45|19|263|

## 🎉 10000 adet mesaj için
| 	QueedDuration(sn)	 | 	ProcessedDuration(sn)	 | 	Cpu(%)	 | Ram(%)	 | IsAsync	 | MIN_CreateDate	 | MAX_CreateDate	 | MIN_QueedDate	 | MAX_QueedDate	 | MIN_ProcessedDate	 | MAX_ProcessedDate	 | TotalProcessedDuration(sn)	 | ProcessedMessageCount_PerSecond	 |
| 	:-----:	 | 	:-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 | :-----:	 | 	:-----:	 |	
|83|0|55.4894|89.8175|0|2023-03-27 22:52:27|2023-03-27 22:52:28|2023-03-27 22:52:29|2023-03-27 22:55:12|2023-03-27 22:52:29|	2023-03-27 22:55:12|163|61|
|7|9|99.9854|91.2392|1|2023-03-27 22:55:40|2023-03-27 22:55:40|2023-03-27 22:55:41|2023-03-27 22:55:54|2023-03-27 22:55:41|	2023-03-27 22:56:11|30|333|
