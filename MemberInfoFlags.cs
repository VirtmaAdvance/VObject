namespace VAdvanceObject
{
	/// <summary>
	/// Provides flag options to indicate the configurations of a class object's member.
	/// </summary>
	[Flags]
	public enum MemberInfoFlags
	{
		/// <summary>
		/// Unknown information.
		/// </summary>
		Unknown=0x0,
		/// <summary>
		/// Member is publicly accessible.
		/// </summary>
		Public=0x1,
		/// <summary>
		/// Member can only be accessed within it's own class.
		/// </summary>
		Private=0x2,
		/// <summary>
		/// Member can only be accessed within it's own class or classes that inherit from it.
		/// </summary>
		Protected=0x4,
		/// <summary>
		/// Member can only be access within it's own assembly.
		/// </summary>
		Internal=0x8,
		/// <summary>
		/// Member is sealed.
		/// </summary>
		Sealed=0x10,
		/// <summary>
		/// Member is static.
		/// </summary>
		Static=0x20,
		/// <summary>
		/// Member can only be read from.
		/// </summary>
		ReadOnly=0x40,
		/// <summary>
		/// Member is a property.
		/// </summary>
		Property=0x80,
		/// <summary>
		/// Member is a field.
		/// </summary>
		Field=0x100,
		/// <summary>
		/// Member is a method.
		/// </summary>
		Method=0x200,
		/// <summary>
		/// Member is a constructor of a class.
		/// </summary>
		Constructor=0x400,
		/// <summary>
		/// Member has a get method.
		/// </summary>
		HasGet=0x800,
		/// <summary>
		/// Member has a set method.
		/// </summary>
		HasSet=0x1000,
		/// <summary>
		/// Member can accept parameters.
		/// </summary>
		AcceptsParameters=0x2000,
		/// <summary>
		/// Member returns nothing.
		/// </summary>
		Void=0x4000,
		/// <summary>
		/// Member is a type info.
		/// </summary>
		TypeInfo=0x8000,
		/// <summary>
		/// Member is an event.
		/// </summary>
		IsEvent=0x10000,
		/// <summary>
		/// Member is a nested type.
		/// </summary>
		IsNestedType=0x20000,
		/// <summary>
		/// Member is custom.
		/// </summary>
		IsCustom=0x40000,
		/// <summary>
		/// Member stores a constant value.
		/// </summary>
		IsConstant=0x80000,
		/// <summary>
		/// Member is virtual.
		/// </summary>
		Virtual=0x100000,
	}
}