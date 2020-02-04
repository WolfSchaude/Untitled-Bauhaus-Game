using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountGebaeude : MonoBehaviour
{
	public int AnzahlArchitektur;
	public int AnzahlMalerei;
	public int AnzahlAustellung;
	public int AnzahlMetall;
	public int AnzahlTisch;
	public int AnzahlLehr;
	public int AnzahlWohn;

	public int GetGesamtAnzahl()
	{
		return AnzahlArchitektur + AnzahlAustellung + AnzahlLehr + AnzahlMalerei + AnzahlMetall + AnzahlTisch;
	}
}
