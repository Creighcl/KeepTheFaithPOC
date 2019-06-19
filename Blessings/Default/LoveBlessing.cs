using System;
using System.Collections.Generic;
using System.Text;

namespace KeepFaith
{
    public class LoveBlessing : Blessing
    {
        public LoveBlessing() : base(new AilmentType[]{
            AilmentType.SAD,
            AilmentType.HEARTBROKEN
        })
        { }
    }
}
