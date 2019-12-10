using System;
using System.Runtime.Serialization;

namespace If.ScooterRental.Services
{

	/// <summary>
	/// Scooter service specific exception.
	/// </summary>
	[Serializable]
	class ScooterServiceException : Exception
    {
		public ScooterServiceException()
			: base()
		{
		}

		public ScooterServiceException(string message)
			: base(message)
		{
		}

		public ScooterServiceException(string message, Exception innerException) :
			base(message, innerException)
		{
		}

		protected ScooterServiceException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
