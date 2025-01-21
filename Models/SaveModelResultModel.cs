using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.WhatsApp.Models
{
    public partial record SaveModelResultModel
    {

        public bool success { get; set; }
        public bool hasError { get; set; }

        public string message { get; set; }
        public List<SaveModelErrorModel> errors { get; set; } = new List<SaveModelErrorModel>() { };
        public object data { get; set; }


    }



    public partial record SaveModelErrorModel
    {

        public string Name { get; set; }
        public List<SaveModelErrorItem> Errors { get; set; } = new List<SaveModelErrorItem>();
    }

    public partial record SaveModelErrorItem
    {

        public string ErrorMessage { get; set; }

    }
}
