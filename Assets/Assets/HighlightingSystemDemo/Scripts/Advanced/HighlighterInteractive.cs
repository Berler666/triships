using UnityEngine;
using System.Collections;
using HighlightingSystem;

public class HighlighterInteractive : HighlighterBase, IHighlightingTarget
{
	#region MonoBehaviour
 	// 
 	public Unit unit;
	public bool canCallFlash=true ;
	protected override void Update()
	{    
		base.Update();
		if (unit.selected && canCallFlash && unit.teamNumber == 1) {  									// selected unit is flashing...
 			h.FlashingOn ();
			canCallFlash = false;
		} 
		if (!unit.selected && !canCallFlash )
			h.FlashingOff (); 																			// this is entered when a unit is unselected...
		
		
		
  
	}
	#endregion

	#region IHighlightingTarget implementation
	// 
	public virtual void OnHighlightingFire1Down()
	{   
		// Switch flashing
		if (unit.teamNumber == 1 && unit.selected ) {
			h.FlashingSwitch ();
 		}
	}
	public virtual void OnHighlightingFire1Held() { }
	public virtual void OnHighlightingFire1Up() { }

	// 
	public virtual void OnHighlightingFire2Down() { }
	public virtual void OnHighlightingFire2Held() { }
	public virtual void OnHighlightingFire2Up()
	{
		// Switch seeThrough mode
		h.seeThrough = !h.seeThrough;
	}

	// 
	public virtual void OnHighlightingMouseOver()
	{
		// Highlight object for one frame
//			 
 		h.On(unit.color);
			
	}

 	#endregion
}