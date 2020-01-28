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
    /// <summary>
    /// Reference to: Bausystem Script on PlayerVariables to get the Data to Display
    /// </summary>
    [SerializeField] Bausystem Script_Bausystem;
    /// <summary>
    /// Reference to: Studenten Script on PlayerVariables to get the Data to Display
    /// </summary>
    [SerializeField] Studenten Script_Studenten;
    /// <summary>
    /// Reference to: Ansehen Script on PlayerVariables to get the Data to Display
    /// </summary>
    [SerializeField] AnsehenScript Script_Ansehen;
    /// <summary>
    /// Reference to: Exponate Script on ExponateSlider to get the Data to Display
    /// </summary>
    [SerializeField] Exponate Script_Exponate;

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
        UpdateText();
    }

    public void UpdateText()
    {
        Vermoegen.text = Script_Money.money.ToString() + " RM";
        Einkommen.text = Script_Money.monthlyCosts.ToString() + " RM/Monat" + " Not Implemented";
        Ausgaben.text = "Diesen Monat: " + " RM" + " Not Implemented";
        PlusMinusTendenz.text = "Not Implemented";

        StudentenAnzahl.text = Script_Studenten.StudentenAnzahl.ToString() + " Studenten";
        StudentenKapazitaet.text = Script_Studenten.studKapazitaet.ToString() + " Studenten";
        StudentenTendenz.text = "Steigend (Zitat Angela Merkel, 2012)";

        AnsehenJetzt.text = Script_Ansehen.Ansehen.ToString() + " Ansehenspunkte";
        AnsehenLetztes.text = "Not implemented";



        ExponateBisherHergestellt.text = "Not Implemented";
        ExponateBisherVerkauft.text = "Not Implemented";
        ExponateBisherVerkauftErloes.text = "Not Implemented";
        ExponateDurschnittQuali.text = "Not Implemented";
        ExponateDurschnittStil.text = "Not Implemented";
        ExponateDurschnittErloes.text = "Not Implemented";
    }
}
