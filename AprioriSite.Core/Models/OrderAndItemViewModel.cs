using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprioriSite.Core.Models
{
    public class OrderAndItemViewModel
    {
        public ItemsDetailsViewModel ItemsDetailsViewModel { get; set; }

        public OrderItemViewModel OrderItemViewModel { get; set; }
    }
}
