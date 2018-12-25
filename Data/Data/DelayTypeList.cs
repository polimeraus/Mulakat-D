using System.Collections.Generic;
using System.Linq;
using DorukOtomotiv.Libraries.Delay;


namespace DorukOtomotiv.Data
{
    public class DelayTypeList
    {
        // properties
        private List<DelayType> _delayTypeList;
        public List<DelayType> delayTypeList
        {
            get {
                return _delayTypeList;
            }
            set {
                _delayTypeList = value;
            }
        }

        // constructor function
        public DelayTypeList()
        {
            //when the object has been instanced the datas is fulled to object
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

        // gives delay type Name from DelayTypeID
        public string GetDelayTypeNameByID(int delayTypeID)
        {
            return delayTypeList.Where(x => x.DelayTypeID == delayTypeID).SingleOrDefault().DelayTypeName.ToString();
        }
    }
}
