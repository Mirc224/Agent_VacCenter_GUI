using OSPABA;
using simulation;

namespace Vac_Center_Agent_Test.simulation
{
	public class SpravaPresunu : MessageForm
    {
		public Sprava PovodnaSprava { get; set; }
		public int CielovaLokacia { get; set; }
		public int EntitaPresunu { get; set; }
		public SpravaPresunu(Simulation sim) :
			base(sim)
		{
		}

		public SpravaPresunu(SpravaPresunu original) :
			base(original)
		{
			// copy() is called in superclass
		}

		override public MessageForm CreateCopy()
		{
			return new SpravaPresunu(this);
		}

		override protected void Copy(MessageForm message)
		{
			base.Copy(message);
			SpravaPresunu original = (SpravaPresunu)message;
			// Copy attributes
		}
	}
}
