using System;
using System.Collections.Generic;
using System.Text;

namespace KeepFaith
{
    public abstract class Blessing
    {
        internal Blessing(AilmentType[] curableAilments)
        {
            CurableAilments = curableAilments;
        }

        public AilmentType[] CurableAilments { get; internal set; }
    }
}
