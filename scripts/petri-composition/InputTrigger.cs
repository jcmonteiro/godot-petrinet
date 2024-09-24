using Godot;

public partial class InputTrigger : Node
{
	[Export]
	public string ActionName { get; set; }

	private PetriTransition _transition;

	public override void _Ready()
	{
		// Locate direct parent transition
		_transition = GetParent<PetriTransition>();
	}

	public override void _Process(double _delta)
	{
		if (Input.IsActionJustPressed(ActionName))
			_transition.Fire();
	}
}
