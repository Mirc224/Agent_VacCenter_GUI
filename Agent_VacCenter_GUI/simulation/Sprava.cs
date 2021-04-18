using OSPABA;
using entities;

namespace simulation
{
	public class Sprava : MessageForm
	{
		public double ZaciatokObsluhy { get; set; }
		public Pacient Pacient { get; set; } = null;
		public Pracovnik Pracovnik { get; set; } = null;
		public Sprava(Simulation sim) :
			base(sim)
		{
		}

		public Sprava(Sprava original) :
			base(original)
		{
			// copy() is called in superclass
		}

		override public MessageForm CreateCopy()
		{
			return new Sprava(this);
		}

		override protected void Copy(MessageForm message)
		{
			base.Copy(message);
			Sprava original = (Sprava)message;
			// Copy attributes
		}
	}
}