
namespace DorukOtomotiv.Libraries.Delay
{
    public class DelayType
    {
        // porperties
        public int DelayTypeID { get; set; }
        public string DelayTypeName { get; set; }


        // constructor function
        public DelayType(int delayTypeID, string delayTypeName)
        {
            DelayTypeID = delayTypeID;
            DelayTypeName = delayTypeName;
        }
    }
}