using System;
using Godot;

namespace PetriInheritance;

public abstract partial class PetriPlace : Node
{
    [Signal]
    public delegate void TokensChangedEventHandler(int tokens);

    [Signal]
    public delegate void ActivationChangedEventHandler(bool isActive);

    [Export]
    public int InitialTokens { get; set; } = 0;

    private int _tokens;

    public int Tokens
    {
        get => _tokens;
    }

    public override void _Ready()
    {
        ActivationChanged += OnActivationChanged;
        TokensChanged += OnTokensChanged;
        Reset();
    }

    public void Reset()
    {
        _tokens = InitialTokens;
        EmitSignal(SignalName.TokensChanged, _tokens);
        if (_tokens > 0)
            EmitSignal(SignalName.ActivationChanged, true);
    }

    public bool AdjustTokens(int amount)
    {
        int changedTokens = _tokens;
        changedTokens += amount;

        if (changedTokens < 0 || amount == 0)
            return false;

        if (_tokens == 0 && changedTokens > 0)
        {
            EmitSignal(SignalName.ActivationChanged, true);
        }
        else if (_tokens > 0 && changedTokens == 0)
        {
            EmitSignal(SignalName.ActivationChanged, false);
        }

        EmitSignal(SignalName.TokensChanged, changedTokens);

        _tokens = changedTokens;
        return true;
    }

    public bool IsActive()
    {
        return _tokens > 0;
    }

    public abstract void OnActivationChanged(bool isActive);
    public abstract void OnTokensChanged(int tokens);
}
