using Godot;

public partial class PetriArc : Node
{
	[Export]
	public PetriPlace Place { get; set; }

	[Export]
	public int Weight { get; set; }
}