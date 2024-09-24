using Godot;
using System;
using System.Diagnostics;

namespace PetriInheritance;

public partial class PlayAnimationPlace : PetriPlace
{
	[Export]
	public AnimatedSprite2D AnimatedSprite { get; set; }

	[Export]
	public string AnimationName { get; set; }

	public override void OnActivationChanged(bool isActive)
	{
		if (isActive)
		{
#if DEBUG
			Debug.Print($"Playing {AnimationName}");
#endif
			AnimatedSprite.Play(AnimationName);
		}
		else
		{
			AnimatedSprite.Stop();
		}
	}

	public override void OnTokensChanged(int _tokens)
	{
		// overridden just for demonstration purposes
	}
}
