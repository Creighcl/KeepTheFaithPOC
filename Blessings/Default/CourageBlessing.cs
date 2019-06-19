using System;
using System.Collections.Generic;
using System.Text;

namespace KeepFaith
{
    public class CourageBlessing : Blessing
    {
        public CourageBlessing() : base(new AilmentType[]{
            AilmentType.WORRIED,
            AilmentType.SCARED
        })
        { }
    }
}
