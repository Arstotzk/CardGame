using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class AttackPattern  {

	[System.Serializable]
	public struct rowData{
		public bool[] row;
	}

	public rowData[] rows = new rowData[3];

    public List<Tuple<int, int>> GetAttackLocations()
    {
		List<Tuple<int, int>> locations = new List<Tuple<int, int>>();

		for (var rowNum = 0; rowNum < 3; rowNum++)
			for (var column = 0; column < 3; column++)
			{
				if (rows[rowNum].row[column] == true)
					locations.Add(new Tuple<int, int>(rowNum, column));
			}
		return locations;
	}
}
