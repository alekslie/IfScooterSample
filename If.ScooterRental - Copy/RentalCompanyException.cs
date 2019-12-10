using System;
using System.Runtime.Serialization;

namespace If.ScooterRental
{
	/// <summary>
	/// Rental company specific exception.
	/// </summary>
	[Serializable]
	class RentalCompanyException : Exception
	{
		public RentalCompanyException()
			: base()
		{
		}

		public RentalCompanyException(string message)
			: base(message)
		{
		}

		public RentalCompanyException(string message, Exception innerException) :
			base(message, innerException)
		{
		}

		protected RentalCompanyException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
