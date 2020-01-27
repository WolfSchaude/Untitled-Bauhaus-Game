using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentSetter : MonoBehaviour
{
    #region Script Referencen um die Daten zu bekommen

    /// <summary>
    /// Reference to: Money Script on PlayerVariables to get the Data to Display
    /// </summary>
    [SerializeField] Money Script_Money;

	#endregion

	#region Finanzen
	//------------------------------------( Finanzen  )------------------------------------//
	/// <summary>
	/// Reference to: Text-Object to change
	/// </summary>
	[SerializeField] public Text Vermoegen;
    /// <summary>
    /// Reference to: Text-Object to change
    /// </summary>
    [SerializeField] public Text Einkommen;
    /// <summary>
    /// Reference to: Text-Object to change
    /// </summary>
    [SerializeField] public Text Ausgaben;
    /// <summary>
    /// Reference to: Text-Object to change
    /// </summary>
    [SerializeField] public Text PlusMinusTendenz;
	#endregion
	#region Studenten
	//------------------------------------( Studenten )------------------------------------//
	/// <summary>
	/// Reference to: Text-Object to change
	/// </summary>
	[SerializeField] Text StudentenAnzahl;
    /// <summary>
    /// Reference to: Text-Object to change
    /// </summary>
    [SerializeField] Text StudentenKapazitaet;
    /// <summary>
    /// Reference to: Text-Object to change
    /// </summary>
    [SerializeField] Text StudentenTendenz;
	#endregion
	#region Ansehen
	//------------------------------------( Ansehen   )------------------------------------//
	/// <summary>
	/// Reference to: Text-Object to change
	/// </summary>
	[SerializeField] Text AnsehenJetzt;    
    /// <summary>
    /// Reference to: Text-Object to change
    /// </summary>
    [SerializeField] Text AnsehenLetztes;
	#endregion
	#region Gebäude
	//------------------------------------( Gebaeude  )------------------------------------//
	/// <summary>
	/// Refernece to: Parent used to Spawn the buttons on the right positions
	/// </summary>
	[SerializeField] Transform ParentWerkstaette;
    /// <summary>
    /// Refernece to: Parent used to Spawn the buttons on the right positions
    /// </summary>
    [SerializeField] Transform ParentLehrsaele;
    /// <summary>
    /// Refernece to: Parent used to Spawn the buttons on the right positions
    /// </summary>
    [SerializeField] Transform ParentWohnheime;

    #endregion
    #region Lehrer
    //------------------------------------( Leher     )------------------------------------//
    /// <summary>
    /// Reference tp: Parent used to Spawn the Formmeister Lists for the already assigned Formmeisters
    /// </summary>
    [SerializeField] Transform ParentZugewiesen;
    /// <summary>
    /// Reference to: Parent used to Spawn the Formmeister Lists for not assigned Formmeisters
    /// </summary>
    [SerializeField] Transform ParentFrei;

    #endregion
    #region Exponate
    //------------------------------------( Exponate  )------------------------------------//
    /// <summary>
    /// Reference to: Text-Object to change
    /// </summary>
    [SerializeField] Text ExponateBisherHergestellt;
    /// <summary>
    /// Reference to: Text-Object to change
    /// </summary>
    [SerializeField] Text ExponateBisherVerkauft;
    /// <summary>
    /// Reference to: Text-Object to change
    /// </summary>
    [SerializeField] Text ExponateBisherVerkauftErloes;
    /// <summary>
    /// Reference to: Text-Object to change
    /// </summary>
    [SerializeField] Text ExponateDurschnittQuali;
    /// <summary>
    /// Reference to: Text-Object to change
    /// </summary>
    [SerializeField] Text ExponateDurschnittStil;
    /// <summary>
    /// Reference to: Text-Object to change
    /// </summary>
    [SerializeField] Text ExponateDurschnittErloes;

	#endregion
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
