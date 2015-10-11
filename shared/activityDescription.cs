using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared
{
    [SerializableAttribute]
    class activityDescription
    {
        // members
        private string activityPath_;

        // ctor
        activityDescription(string activityPath)
        {
            activityPath_ = activityPath;
        }

        public string activityPath
        {
            get
            {
                return activityPath_;
            }
        }
    }
}
