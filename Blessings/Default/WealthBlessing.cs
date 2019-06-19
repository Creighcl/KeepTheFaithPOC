using System;
using System.Collections.Generic;
using System.Text;

namespace KeepFaith
{
    public class WealthBlessing : Blessing
    {
        public WealthBlessing() : base(new AilmentType[]{
            AilmentType.NEEDY,
            AilmentType.DESPERATE
        })
        { }
    }
}
