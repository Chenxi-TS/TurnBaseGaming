using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE { get; private set; }

    InputHandler inputHandler;
    PhaseManager phaseManager;
    PartyManager partyManager;
    StatusEffectFactory statusEffectFactory;
    public InputHandler InputHander { get { return inputHandler; } }
    public PhaseManager PhaseManager { get { return phaseManager; } }
    public PartyManager PartyManager { get { return partyManager; } }
    public StatusEffectFactory StatusEffectFactory { get { return statusEffectFactory; } }

    private void Awake()
    {
        if (GameManager.INSTANCE != null && GameManager.INSTANCE != this)
        {
            Destroy(this); 
            return;
        }
        INSTANCE = this;
        DontDestroyOnLoad(this.gameObject);
        Debug.LogWarning("GameManager initialized");

        inputHandler = new InputHandler();
        partyManager = new PartyManager();
        phaseManager = new PhaseManager(inputHandler, partyManager);
        statusEffectFactory = new StatusEffectFactory();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
