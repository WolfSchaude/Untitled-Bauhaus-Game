using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveableInterface
{
	/// <summary>
	/// Needs to be registered at the Save-Event. Creates a part of the Save-Class und enters into the istance in SavegameManager
	/// </summary>
	void Save();
	/// <summary>
	/// Needs to be registered at the Load-Event. Takes his part of the Save-Class instance passed with the Event
	/// </summary>
	/// <param name="save"></param>
	void Load(Save save);
	/// <summary>
	/// Loads the beginning of the game with standard values
	/// </summary>
	void LoadStart();
}
