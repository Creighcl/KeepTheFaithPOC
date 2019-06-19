using System;
using System.Collections.Generic;
using System.Text;

namespace KeepFaith
{
    public class GeneralBlessing : Blessing
    {
        public GeneralBlessing() : base(new AilmentType[]{
            AilmentType.NEEDY,
            AilmentType.SICK,
            AilmentType.WORRIED,
            AilmentType.ANGRY,
            AilmentType.SAD
        }) { }
    }
}
