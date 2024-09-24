using Godot;
using System.Collections.Generic;

namespace PetriInheritance;

public partial class PetriNetwork : Node
{
    private List<PetriPlace> _places = new List<PetriPlace>();
    private List<PetriTransition> _transitions = new List<PetriTransition>();

    public override void _Ready()
    {
        foreach (Node node in GetChildren())
        {
            if (node is PetriPlace place)
            {
                _places.Add(place);
            }
            else if (node is PetriTransition transition)
            {
                _transitions.Add(transition);
            }
        }
    }

    public override void _Process(double _delta)
    {
        // GD.Print("Network state:");
        // foreach (PetriPlace place in _places)
        // {
        //     GD.Print($"\t{place.Name} [{place.Tokens}]");
        // }
        // foreach (PetriTransition petriTransition in _transitions)
        // {
        //     GD.Print($"\t{petriTransition.Name} [{(petriTransition.IsEnabled() ? "Enabled" : "Disabled")}]");
        // }
    }
}
