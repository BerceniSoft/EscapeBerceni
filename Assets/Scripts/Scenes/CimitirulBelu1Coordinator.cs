using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CimitirulBelu1Coordinator : MonoBehaviour
{
    private const string IS_FIRST_LOAD_KEY = "IS_FIRST_LOAD";
    private const string HAS_PLAYER_ENTERED_KEY = "HAS_PLAYER_ENTERED";

    private SceneStorage sceneStorage;

    public DialogManager dialogManager;
    public MainCharacterMovement mainCharacterMovement;

    void ShowDialog()
    {
        //  We'll show all 8 dialog lines one after the other
        if(this.dialogManager.currentDialogLineIndex < 8)
        {
            this.dialogManager.ShowDialog(this.ShowDialog);
        }
        else
        {
            // Done with the intro
            this.sceneStorage.AddKey(ScenesIds.CIMITIRUL_BELU_1, IS_FIRST_LOAD_KEY, "false");
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        this.sceneStorage = SceneStorage.getInstance();
      
    }   

    // Update is called once per frame
    void Update()
    {
        var isFirstLoad = this.sceneStorage.GetKey(ScenesIds.CIMITIRUL_BELU_1, IS_FIRST_LOAD_KEY) == null;
        if(isFirstLoad)
        {
            var hasPlayerEntered = this.sceneStorage.GetKey(ScenesIds.CIMITIRUL_BELU_1, HAS_PLAYER_ENTERED_KEY) != null;
            if(!hasPlayerEntered)
            { 
               // Move the character in scene
                this.mainCharacterMovement.SetDestination(new Vector2(-6, -2), false);
                this.sceneStorage.AddKey(ScenesIds.CIMITIRUL_BELU_1, HAS_PLAYER_ENTERED_KEY, "true");
            }

            // After the movment is done, show the dialog
            if(!this.dialogManager.IsDialogBeingShown && !this.mainCharacterMovement.isMoving)
            { 
                this.ShowDialog();
            }   
        }
    }
}
