using Godot;

public abstract partial class PetriPlaceAction : Node
{
    public override void _Ready()
    {
        GetParent<PetriPlace>().ActivationChanged += OnActivationChanged;
        GetParent<PetriPlace>().TokensChanged += OnTokensChanged;
    }

    protected abstract void OnActivationChanged(bool isActive);

    protected abstract void OnTokensChanged(int tokens);
}
