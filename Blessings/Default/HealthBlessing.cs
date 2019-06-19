using System;
using System.Collections.Generic;
using System.Text;

namespace KeepFaith
{
    public class HealthBlessing : Blessing
    {
        public HealthBlessing() : base(new AilmentType[]{
            AilmentType.SICK,
            AilmentType.DYING
        })
        { }
    }
}
