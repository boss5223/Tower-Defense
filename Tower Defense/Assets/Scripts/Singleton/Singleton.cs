/// <summary>
/// Generic class which makes non singleton class to be singleton.
/// Calling singleton instance of class should be Singleton<T>.Instance, otherwise the returned class is not singleton one. 
/// </summary>
/// <typeparam name="T">Genric class type to be singletonized</typeparam>

	public class Singleton<T> where T : class, new()
	{
		/// <summary>
		/// Private constuctor to avoid this class instantiated
		/// </summary>
		protected Singleton ()
		{
		}

		/// <summary>
		/// Property to get access to singleton instance
		/// </summary>
		public static T Instance {
			get {
				return Nested.instance;
			}
		}

		/// <summary>
		/// Private nested class which acts as singleton class instantiator. This class should not be accessible outside <see cref="Singleton<T>"/>
		/// </summary>
		class Nested
		{
			/// <summary>
			/// Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
			/// </summary>
			static Nested ()
			{
			}

			/// <summary>
			/// Static instance variable
			/// </summary>
			internal static readonly T instance = new T ();
		}
	}