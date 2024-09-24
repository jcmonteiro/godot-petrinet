using Godot;
using System;
using System.Diagnostics;

namespace PetriComposition;

public partial class SpriteAction : PetriPlaceAction
{
	[Export]
	public AnimatedSprite2D AnimatedSprite { get; set; }

	[Export]
	public string AnimationName { get; set; }

	protected override void OnActivationChanged(bool isActive)
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

	protected override void OnTokensChanged(int _tokens)
	{
	}
}
