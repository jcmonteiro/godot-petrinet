using Godot;

namespace PetriInheritance;

public partial class InputTrigger : PetriTransition
{
	[Export]
	public string ActionName { get; set; }

	private PetriTransition _transition;

	public override void _Ready()
	{
	}

	public override void _Process(double _delta)
	{
		if (Input.IsActionJustPressed(ActionName))
			Fire();
	}
}
