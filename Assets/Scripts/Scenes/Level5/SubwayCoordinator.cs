using System;
using System.Collections;
using Dialog;
using DialogTrees.Level5;
using Movement;
using UnityEngine;

namespace Scenes.Level5
{
    public class SubwayCoordinator : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer backgroundRenderer;

        [SerializeField]
        private Sprite backgroundNoLights;

        [SerializeField]
        private Sprite backgroundWithLights;

        [SerializeField]
        private GameObject tint;

        [SerializeField]
        private MainCharacterMovement characterMovement;

        [SerializeField]
        private DialogManager dialogManager;

        [SerializeField]
        private BlackoutStartDialogTree blackoutStartDialogTree;

        [SerializeField]
        private AfterBlackoutDialogTree afterBlackoutDialogTree;

        [SerializeField] 
        private ElectricPanel electricPanel;

        private void Start()
        {
            electricPanel.OnClose += EndBlackout;
        }

        public void StartBlackout()
        {
            tint.SetActive(true);
            backgroundRenderer.sprite = backgroundNoLights;
            characterMovement.StopMovement();

            dialogManager.dialogTree = blackoutStartDialogTree;
            dialogManager.ShowDialog();
        }

        public void EndBlackout()
        {
            tint.SetActive(false);
            backgroundRenderer.sprite = backgroundWithLights;
            characterMovement.StopMovement();

            dialogManager.currentDialogLineIndex = 0;
            dialogManager.dialogTree = afterBlackoutDialogTree;
            dialogManager.ShowDialog();
        }
    }
}