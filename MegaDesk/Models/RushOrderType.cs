using System.ComponentModel.DataAnnotations;

namespace MegaDesk.Models
{
    public enum RushOrderType
    {
        Standard = 0,

        [Display( Name = "3 Day" )]
        ThreeDay = 1,

        [Display( Name = "5 Day" )]
        FiveDay = 2,

        [Display( Name = "7 Day" )]
        SevenDay = 3
    }

    //public class RushOrderType
    //{
    //    public int RushOrderTypeId { get; set; }
    //    public string RushOrderName { get; set; }
    //    public decimal TierOnePrice { get; set; }
    //    public decimal TierTwoPrice { get; set; }
    //    public decimal SevenDay { get; set; }
    //}
}
