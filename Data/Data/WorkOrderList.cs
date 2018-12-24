using System;
using System.Collections.Generic;
using DorukOtomotiv.Libraries.WorkOrder;
using System.Globalization;

namespace DorukOtomotiv.Data
{
    public class WorkOrderList
    {
        // properties
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
}
