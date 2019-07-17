using System.ComponentModel;

namespace SvetulkaApp.Data.Models.Enums
{
    [DefaultValue(Ordered)]
    public enum OrderStatus
    {
        Ordered = 1,
        Shipped = 2,
        Delivered = 3,
    }
}
