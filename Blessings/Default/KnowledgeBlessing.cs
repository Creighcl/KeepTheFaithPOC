using System;
using System.Collections.Generic;
using System.Text;

namespace KeepFaith
{
    public class KnowledgeBlessing : Blessing
    {
        public KnowledgeBlessing() : base(new AilmentType[]{
            AilmentType.ANGRY,
            AilmentType.IGNORANT
        })
        { }
    }
}
