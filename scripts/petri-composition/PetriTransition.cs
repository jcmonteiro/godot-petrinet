using Godot;

namespace PetriComposition;

public partial class PetriTransition : Node
{
    [Export]
    public Godot.Collections.Array<PetriArc> InputArcs { get; set; }

    [Export]
    public Godot.Collections.Array<PetriArc> OutputArcs { get; set; }

    public bool IsEnabled()
    {
        foreach (var arc in InputArcs)
        {
            PetriPlace place = arc.Place;
            int tokensRequired = arc.Weight;
            if (place.Tokens < tokensRequired)
                return false;
        }
        return true;
    }

    public void Fire()
    {
        if (!IsEnabled())
        {
#if DEBUG
            GD.Print($"Transition {Name} is not enabled.");
#endif
            return;
        }

        // Consume tokens from input places
        foreach (var arc in InputArcs)
        {
            PetriPlace place = arc.Place;
            int tokensRequired = arc.Weight;
            place.AdjustTokens(-tokensRequired);
        }

        // Produce tokens in output places
        foreach (var arc in OutputArcs)
        {
            PetriPlace place = arc.Place;
            int tokensRequired = arc.Weight;
            place.AdjustTokens(tokensRequired);
        }

#if DEBUG
        GD.Print($"Transition {Name} fired.");
#endif
    }
}
