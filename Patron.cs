using System;
using System.Collections.Generic;
using System.Text;

namespace KeepFaith
{
    public class Patron
    {
        public Patron(List<AilmentType> ailments, int faithInWallet)
        {
            Ailments = ailments;
            FaithInWallet = faithInWallet;
            BlessingReceived = null;
        }

        public Blessing BlessingReceived { get; private set; }
        public List<AilmentType> Ailments { get; private set; }
        public int FaithInWallet { get; private set; }

        public int Tithe()
        {
            if (Ailments.Count > 0)
            {
                int roughlyAThird = FaithInWallet / 3;
                FaithInWallet -= Math.Clamp(roughlyAThird, 0, FaithInWallet);
                return roughlyAThird;
            }

            return 0;
        }

        public int PickPocket()
        {
            int pocketed = FaithInWallet > 0 ? 1 : 0;
            FaithInWallet -= pocketed;
            return pocketed;
        }

        public void ReceiveBlessing(Blessing blessing)
        {
            BlessingReceived = blessing;
            foreach(AilmentType curableAilment in blessing.CurableAilments)
            {
                if (Ailments.Contains(curableAilment))
                {
                    Ailments.Remove(curableAilment);
                    return;
                }
            }
        }
    }
}
