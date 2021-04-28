using System;
using System.Collections.Generic;
using System.Text;

namespace entities
{
    public class Sestricka : Pracovnik
    {
        /**
         * Potomok triedy pracovnik, ktory okrem spolocnych atributov nesie aj inofrmaciu o maximalnom pocte striekaciek a o aktualnom pocte naplnenych
         * striekaciek.
         */
        public int PocetNaplnenych { get; set; } = 20;
        public int MaxPocetStriekaciek { get; set; } = 20;
        public Sestricka(OSPABA.Simulation sim)
            : base(sim) {}

        override
        public void Clear()
        {
            base.Clear();
            PocetNaplnenych = MaxPocetStriekaciek;
        }
    }
}
