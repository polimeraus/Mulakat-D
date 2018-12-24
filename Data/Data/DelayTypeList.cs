using System;
using System.Collections.Generic;
using System.Linq;
using DorukOtomotiv.Libraries.Delay;


namespace DorukOtomotiv.Data
{
    public class DelayTypeList
    {
        // properties
        public List<DelayType> delayTypeList { get; set; }

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

        public string GetDelayTypeNameByID(int delayTypeID)
        {
            return delayTypeList.Where(x => x.DelayTypeID == delayTypeID).SingleOrDefault().DelayTypeName.ToString();
        }
    }
}
