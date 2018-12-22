using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using DorukOtomotiv.Libraries.WorkOrder;
using DorukOtomotiv.Libraries.Delay;

namespace DorukOtomotiv.Data
{
    public class WorkOrderList
    {
        public List<WorkOrder> workOrderList { get; set; }

        // constructor function
        public WorkOrderList()
        {
            setData();  //when the object has been instanced the datas is fulled to object
        }

        // workOrderList is being fulled with data
        private void setData()
        {
            workOrderList = new List<WorkOrder>
                {
                    new WorkOrder(1001,
                    DateTime.ParseExact("01.01.2017 08:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("01.01.2017 16:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),

                    new WorkOrder(1002,
                    DateTime.ParseExact("01.01.2017 16:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("02.01.2017 00:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),

                    new WorkOrder(1003,
                    DateTime.ParseExact("02.01.2017 00:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("02.01.2017 08:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),

                    new WorkOrder(1004,
                    DateTime.ParseExact("02.01.2017 08:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("02.01.2017 16:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),

                    new WorkOrder(1005,
                    DateTime.ParseExact("02.01.2017 16:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("03.01.2017 00:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),

                    new WorkOrder(1006,
                    DateTime.ParseExact("03.01.2017 00:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("03.01.2017 08:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),

                    new WorkOrder(1007,
                    DateTime.ParseExact("03.01.2017 08:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("03.01.2017 16:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),

                    new WorkOrder(1008,
                    DateTime.ParseExact("03.01.2017 16:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("04.01.2017 00:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),

                    new WorkOrder(1009,
                    DateTime.ParseExact("04.01.2017 00:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("04.01.2017 08:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture))                    
                };
        }
    }

    public class DelayRecordList
    {
        //bu sonradan private yapılıp arabirim üretilecek, ayrıca bu sınıflar interface den türeyecek, ayrıca datagirişi de öyle tekrar eden kültür kodları olmayacak, tek fonksyondan yapılacak, kpod tekrarı hoşl değil
        public List<DelayRecord> delayRecordList { get; set; }

        // constructor function
        public DelayRecordList()
        {
            //when the object has been instanced the datas is fulled to object
            setData();  
        }

        // workOrderList is being fulled with data
        private void setData()
        {
            delayRecordList = new List<DelayRecord>
                {
                    new DelayRecord(1,
                    (int) DelayTypes.Mola,
                    DateTime.ParseExact("01.01.2017 10:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("01.01.2017 10:10:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),
                    
                    new DelayRecord(2,
                    (int) DelayTypes.Arıza,
                    DateTime.ParseExact("01.01.2017 10:30:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("01.01.2017 11:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),

                    new DelayRecord(3,
                    (int) DelayTypes.Mola,
                    DateTime.ParseExact("01.01.2017 12:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("01.01.2017 12:30:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),

                    new DelayRecord(4,
                    (int) DelayTypes.Mola,
                    DateTime.ParseExact("01.01.2017 14:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("01.01.2017 14:10:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),

                    new DelayRecord(5,
                    (int) DelayTypes.Setup,
                    DateTime.ParseExact("01.01.2017 15:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("01.01.2017 16:30:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),

                    new DelayRecord(6,
                    (int) DelayTypes.Mola,
                    DateTime.ParseExact("01.01.2017 18:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("01.01.2017 18:10:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),

                    new DelayRecord(7,
                    (int) DelayTypes.Mola,
                    DateTime.ParseExact("01.01.2017 20:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("01.01.2017 20:30:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),

                    new DelayRecord(8,
                    (int) DelayTypes.Mola,
                    DateTime.ParseExact("01.01.2017 22:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("01.01.2017 22:10:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),

                    new DelayRecord(9,
                    (int) DelayTypes.Arge,
                    DateTime.ParseExact("01.01.2017 23:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("02.01.2017 08:30:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),

                    new DelayRecord(10,
                    (int) DelayTypes.Mola,
                    DateTime.ParseExact("02.01.2017 10:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("02.01.2017 10:10:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),

                    new DelayRecord(11,
                    (int) DelayTypes.Mola,
                    DateTime.ParseExact("02.01.2017 12:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("02.01.2017 12:30:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),

                    new DelayRecord(12,
                    (int) DelayTypes.Arıza,
                    DateTime.ParseExact("02.01.2017 13:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("02.01.2017 13:45:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),

                    new DelayRecord(13,
                    (int) DelayTypes.Mola,
                    DateTime.ParseExact("02.01.2017 14:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("02.01.2017 14:10:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),

                    new DelayRecord(14,
                    (int) DelayTypes.Mola,
                    DateTime.ParseExact("02.01.2017 18:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("02.01.2017 18:10:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),
                    
                    new DelayRecord(15,
                    (int) DelayTypes.Arge,
                    DateTime.ParseExact("02.01.2017 20:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("03.01.2017 02:10:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),
                    
                    new DelayRecord(16,
                    (int) DelayTypes.Mola,
                    DateTime.ParseExact("03.01.2017 04:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("03.01.2017 04:30:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),
                    
                    new DelayRecord(17,
                    (int) DelayTypes.Setup,
                    DateTime.ParseExact("03.01.2017 06:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("03.01.2017 09:30:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),
                    
                    new DelayRecord(18,
                    (int) DelayTypes.Mola,
                    DateTime.ParseExact("03.01.2017 10:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("03.01.2017 10:10:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),
                    
                    new DelayRecord(19,
                    (int) DelayTypes.Mola,
                    DateTime.ParseExact("03.01.2017 12:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("03.01.2017 12:30:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),
                    
                    new DelayRecord(20,
                    (int) DelayTypes.Mola,
                    DateTime.ParseExact("03.01.2017 14:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("03.01.2017 14:10:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),
                    
                    new DelayRecord(21,
                    (int) DelayTypes.Arıza,
                    DateTime.ParseExact("03.01.2017 15:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("03.01.2017 18:45:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),

                    new DelayRecord(22,
                    (int) DelayTypes.Mola,
                    DateTime.ParseExact("03.01.2017 20:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("03.01.2017 20:30:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)),

                    new DelayRecord(23,
                    (int) DelayTypes.Mola,
                    DateTime.ParseExact("03.01.2017 22:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact("03.01.2017 22:10:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture))
                };
        }
    }




    public class DelayTypeList
    {
        private List<DelayType> delayTypeList { get; set; }

        // constructor function
        public DelayTypeList()
        {
            setData();
        }

        // delayTypeList is being fulled with data
        private void setData()
        {
            delayTypeList = new List<DelayType>
            {
                new DelayType(1, "Mola"),
                new DelayType(2, "Arıza"),
                new DelayType(3, "Setup"),
                new DelayType(4, "Arge")
            };
        }
    }

    
    // for coding simplicity
    public enum DelayTypes
    {
        Mola = 1,
        Arıza = 2,
        Setup = 3,
        Arge = 4
    }
}