using System;
using System.Collections.Generic;
using System.Text;
using Upload.Enum;

namespace Upload.Entity
{
    public class BaseModel
    {
        public object OldData { get; set; }

        public ModelState? State { get; set; }

    }
}
