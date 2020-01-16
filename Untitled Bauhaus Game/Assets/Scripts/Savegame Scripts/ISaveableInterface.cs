using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveableInterface
{
	void Save();

	void Load(Save save);
}
