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
    [SerializeField] Exponat_Memory Script_ExponatMemory;

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
    [SerializeField] Button PreFab_Building;

    List<Button> WerkstattButtons = new List<Button>();
    List<Button> WohnheimButtons = new List<Button>();
    List<Button> LehrsaalButtons = new List<Button>();

    List<Button> Buttons;

    public enum Typ { Undefiniert, Architekturwerkstatt, Ausstellungsgestaltung, Malerei, Metallwerkstatt, Tischlerei, Wohnheim, Lehrsaal };

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
        for (int i = 0; i < Script_Bausystem.UsableMainTypeStructures(1); i++)
        {
            
        }

        for (int i = 0; i < Script_Bausystem.UsableMainTypeStructures(2); i++)
        {

        }

        for (int i = 0; i < Script_Bausystem.UsableMainTypeStructures(3); i++)
        {

        }

        UpdateText();
    }

    public void UpdateText()
    {
        StartCoroutine(UpdateTextInternal());
    }

    private IEnumerator UpdateTextInternal()
    {
        yield return new WaitForEndOfFrame();

        Vermoegen.text = Script_Money.money.ToString() + " RM";
        Einkommen.text = Script_Money.monthlyCosts.ToString() + " RM/Monat" + " Not Implemented";
        Ausgaben.text = "Diesen Monat: " + " RM";
        PlusMinusTendenz.text = "Not Implemented";

        StudentenAnzahl.text = Script_Studenten.StudentenAnzahl.ToString() + " Studenten";
        StudentenKapazitaet.text = Script_Studenten.studKapazitaet.ToString() + " Studenten";
        StudentenTendenz.text = "Steigend (Zitat Angela Merkel, 2012)";

        AnsehenJetzt.text = Script_Ansehen.Ansehen.ToString() + " Ansehenspunkte";
        AnsehenLetztes.text = "Not implemented";



        ExponateBisherHergestellt.text = Script_Exponate.exponatCounter.ToString() + " Exponate";
        ExponateBisherVerkauft.text = Script_Exponate.BisherVerkauftAnzahl + " Exponate";
        ExponateBisherVerkauftErloes.text = Script_Exponate.BisherGebautErloes + " RM";
        ExponateDurschnittQuali.text = "100%";
        ExponateDurschnittStil.text = "Not Implemented";
        if (Script_Exponate.exponatCounter != 0)
        {
            ExponateDurschnittErloes.text = (Script_Exponate.BisherGebautErloes / Script_Exponate.BisherVerkauftAnzahl).ToString() + " RM/Exponat";
        }
        else
        {
            ExponateDurschnittErloes.text = "0 RM/Exponat";
        }
    }

    public void NewBuildingButton(int uniqueStructureID, int MainType, int Type, int MainTypeID)
    {
        Debug.Log("EventButton triggert");

        switch (MainType)
        {
            case 1:

                var x = Instantiate(PreFab_Building, ParentWerkstaette);

                x.GetComponent<StatisticMenuBuildingButton_Memory>().SetValues(uniqueStructureID, MainType, Type, MainTypeID, Script_Bausystem);

                x.GetComponentInChildren<Text>().text = ((Typ)Type).ToString();

                WerkstattButtons.Add(x);

                break;
            case 2:

                var y = Instantiate(PreFab_Building, ParentWohnheime);

                y.GetComponent<StatisticMenuBuildingButton_Memory>().SetValues(uniqueStructureID, MainType, Type, MainTypeID, Script_Bausystem);

                y.GetComponentInChildren<Text>().text = ((Typ)Type).ToString();

                WohnheimButtons.Add(y);

                break;
            case 3:

                var z = Instantiate(PreFab_Building, ParentLehrsaele);

                z.GetComponent<StatisticMenuBuildingButton_Memory>().SetValues(uniqueStructureID, MainType, Type, MainTypeID, Script_Bausystem);

                z.GetComponentInChildren<Text>().text = ((Typ)Type).ToString();

                WohnheimButtons.Add(z);

                break;
            default:
                break;
        }
    }
}
