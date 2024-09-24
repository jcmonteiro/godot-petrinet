using Godot;

namespace PetriInheritance;

public partial class PetriArc : Node
{
	[Export]
	public PetriPlace Place { get; set; }

	[Export(PropertyHint.Range, "1,1000000")]
	public int Weight { get; set; }
}
