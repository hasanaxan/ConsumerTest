using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsumerSync
{
    internal class MessageObject
    {
        /// <summary>
        /// Mesaj Unique Id'si
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Mesajın oluşturulma tarihi
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Mesajın kuyruğa eklenme tarihi
        /// </summary>
        public DateTime QueedDate { get; set; }
        /// <summary>
        /// Mesajın işlenme tarihi
        /// </summary>
        public DateTime ProcessedDate { get; set; }
        //1000, 5000 ,10000 binlik mesaj adeti gruplama
        public int MessageGroup { get; set; }
        /// <summary>
        /// Mesajın çalışma kuyruğua gönderilirken belirlenen sırası
        /// </summary>
        public int MessageOrder { get; set; }
    }
}
