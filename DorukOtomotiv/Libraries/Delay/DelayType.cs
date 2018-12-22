using System;

namespace DorukOtomotiv.Libraries.Delay
{
    public class DelayType
    {
        int DelayTypeID { get; set; }
        string DelayTypeName { get; set; }

        // constructor function
        public DelayType(int delayTypeID, string delayTypeName)
        {
            DelayTypeID = delayTypeID;
            DelayTypeName = delayTypeName;
        }
    }
}